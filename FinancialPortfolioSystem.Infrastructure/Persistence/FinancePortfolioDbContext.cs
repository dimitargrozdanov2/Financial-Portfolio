using FinancialPortfolioSystem.Domain.Models.Assets;
using FinancialPortfolioSystem.Domain.Models.Client;
using FinancialPortfolioSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialPortfolioSystem.Infrastructure.Persistence;

internal class FinancePortfolioDbContext : IdentityDbContext<User>
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

        builder.Entity<Asset>();

        base.OnModelCreating(builder);
    }
}
