using FinancialPortfolioSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolioSystem.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration);

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

        // TO DO: register repositories here
    }
}
