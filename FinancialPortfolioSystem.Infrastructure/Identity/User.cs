using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.AspNetCore.Identity;

namespace FinancialPortfolioSystem.Infrastructure.Identity;

public class User : IdentityUser
{
    internal User(string email)
        : base(email)
        => Email = email;

    public ClientPortfolio Portfolio { get; private set; }
}
