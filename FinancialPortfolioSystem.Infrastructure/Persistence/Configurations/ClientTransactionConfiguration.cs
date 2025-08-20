using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations
{
    internal class ClientTransactionConfiguration : IEntityTypeConfiguration<ClientTransaction>
    {
        public void Configure(EntityTypeBuilder<ClientTransaction> builder)
        {
            builder
                .HasKey(ct => ct.Id);

            builder
                .Property(ct => ct.AssetId)
                .IsRequired();

            builder.Property(a => a.Type)
                .HasConversion(
                    at => at.Value,
                    value => ClientTransactionType.FromValue<ClientTransactionType>(value))
                .IsRequired();

            builder
                .Property(ct => ct.Quantity)
                .IsRequired();

            builder
                .Property(a => a.PricePerUnit)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(a => a.Timestamp)
                .HasDefaultValue(DateTime.UtcNow);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_ClientTransaction_Quantity", "[Quantity] >= 1");
                t.HasCheckConstraint("CK_ClientTransaction_PricePerUnit", "[PricePerUnit] > 0");
            });
        }
    }
}
