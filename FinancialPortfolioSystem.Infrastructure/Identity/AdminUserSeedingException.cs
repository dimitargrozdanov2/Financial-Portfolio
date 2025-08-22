using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Infrastructure.Identity
{
    public class AdminUserSeedingException : Exception
    {
        public AdminUserSeedingException(string message) : base(message) { }
    }
}
