using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using static FinancialPortfolioSystem.Infrastructure.Identity.IdentityConstants.Role;
using static FinancialPortfolioSystem.Infrastructure.Identity.IdentityConstants.Admin;

namespace FinancialPortfolioSystem.Infrastructure.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(
            IConfiguration configuration,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var adminRole = AdminRole;
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
            var adminEmail = configuration[AdminEmailConfiguration] ?? AdminDefaultEmail;
            var adminPassword = configuration[AdminPasswordConfiguration] ?? AdminDefaultPassword;// choose strong password or from config

            var user = await userManager.FindByEmailAsync(adminEmail);
            if (user == null)
            {
                user = new User(adminEmail);

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new AdminUserSeedingException("Failed to seed admin user: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.IsInRoleAsync(user, adminRole))
            {
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }
    }
}
