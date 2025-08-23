using FinancialPortfolioSystem.Application;
using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios;
using FinancialPortfolioSystem.Application.Features.Identity;
using FinancialPortfolioSystem.Infrastructure.Identity;
using FinancialPortfolioSystem.Infrastructure.Persistence;
using FinancialPortfolioSystem.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FinancialPortfolioSystem.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddIdentity(configuration);

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<FinancePortfolioDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(FinancePortfolioDbContext)
                                .Assembly.FullName)))
                .AddTransient<IPortfolioDbInitializer, PortfolioDbInitializer>();

        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
            => services
                .AddTransient<IAssetRepository, AssetRepository>()
                .AddTransient<IClientPortfolioRepository, ClientPortfolioRepository>();

        private static IServiceCollection AddIdentity(
                   this IServiceCollection services,
                   IConfiguration configuration)
        {
            services
                
                .AddIdentityCore<User>(options =>
                {
                    // Password settings
                    options.Password.RequiredLength = 8;          // Minimum 8 characters
                    options.Password.RequireDigit = true;         // At least one number
                    options.Password.RequireLowercase = true;     // At least one lowercase
                    options.Password.RequireUppercase = true;     // At least one uppercase
                    options.Password.RequireNonAlphanumeric = true; // At least one symbol (!, @, #, etc.)

                    // Lockout settings (optional but recommended)
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings (optional)
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FinancePortfolioDbContext>();

            var secret = configuration
                           .GetSection(nameof(ApplicationSettings))
                           .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false; //this should be true in production!
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddTransient<IIdentity, IdentityService>();
            return services;
        }

        public static async Task SeedAdminAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var configuration = services.GetRequiredService<IConfiguration>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await IdentitySeeder.SeedAdminAsync(configuration, userManager, roleManager);
        }
    }
}
