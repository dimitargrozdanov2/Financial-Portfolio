using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Infrastructure.Identity
{
    public static class IdentityConstants
    {
        public class Role
        {
            public const string AdminRole = "Admin";
            public const string UserRole = "Client";

        }

        public class Admin
        {
            public const string AdminDefaultEmail = "admin@admin.com";
            public const string AdminDefaultPassword = "ChangeThisASAP#2!";
            public const string AdminEmailConfiguration = "AdminSettings:Email";
            public const string AdminPasswordConfiguration = "AdminSettings:Password";
        }
    }
}
