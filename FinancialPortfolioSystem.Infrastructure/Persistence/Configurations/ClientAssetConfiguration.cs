using FinancialPortfolioSystem.Domain.Models.Assets;
using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations;

internal class ClientAssetConfiguration : IEntityTypeConfiguration<ClientAsset>
{
    public void Configure(EntityTypeBuilder<ClientAsset> builder)
    {
        builder
            .HasKey(ca => ca.Id);

        builder
            .Property(ca => ca.AssetId)
            .IsRequired();

        builder
            .HasOne<Asset>()
            .WithMany()
            .HasForeignKey(ca  => ca.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(ca => ca.Quantity)
            .IsRequired();

        builder
            .Property(ca => ca.AverageCost)
            .HasColumnType("decimal(18,2)")
            .IsRequired();


        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_ClientAsset_Quantity", "[Quantity] >= 0");
            t.HasCheckConstraint("CK_ClientAsset_AverageCost", "[AverageCost] >= 0");
        });
    }
}
