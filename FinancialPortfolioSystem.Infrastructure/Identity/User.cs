using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public ClientPortfolio Portfolio { get; private set; }
    }
}
