using FinancialPortfolioSystem.Domain.Models.Assets;
using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioSystem.Infrastructure.Persistence
{
    internal class FinancePortfolioDbContext : DbContext
    {

        public FinancePortfolioDbContext(DbContextOptions<FinancePortfolioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<ClientPortfolio> ClientPortfolios { get; set; }

        public DbSet<ClientTransaction> ClientTransactions { get; set; }

    }
}
