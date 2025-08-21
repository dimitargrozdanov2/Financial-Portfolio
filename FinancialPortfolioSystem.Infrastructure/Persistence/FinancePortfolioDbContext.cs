using FinancialPortfolioSystem.Domain.Models.Assets;
using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialPortfolioSystem.Infrastructure.Persistence
{
    internal class FinancePortfolioDbContext : DbContext
    {

        public FinancePortfolioDbContext(DbContextOptions<FinancePortfolioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<ClientAsset> ClientAssets { get; set; }
        public DbSet<ClientPortfolio> ClientPortfolios { get; set; }

        public DbSet<ClientTransaction> ClientTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
