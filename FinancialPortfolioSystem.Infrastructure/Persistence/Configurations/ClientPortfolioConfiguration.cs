using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations;

internal class ClientPortfolioConfiguration : IEntityTypeConfiguration<ClientPortfolio>
{
    public void Configure(EntityTypeBuilder<ClientPortfolio> builder)
    {
        builder
            .HasKey(cp => cp.Id);

        builder
            .Property(ct => ct.UserId)
            .IsRequired();

        builder
            .HasMany(ct => ct.ClientAssets)
            .WithOne()
            .Metadata
            .PrincipalToDependent
            .SetField("_clientAssets");

        builder
            .HasMany(ct => ct.Transactions)
            .WithOne()
            .Metadata
            .PrincipalToDependent
            .SetField("_clientTransactions");
    }
}
