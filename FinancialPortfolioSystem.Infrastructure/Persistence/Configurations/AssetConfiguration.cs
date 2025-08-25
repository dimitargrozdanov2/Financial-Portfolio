using FinancialPortfolioSystem.Domain.Models.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Configurations;

internal class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder.Property(a => a.AssetType)
            .HasConversion(
                at => at.Value,
                value => AssetType.FromValue<AssetType>(value))
            .IsRequired();

        builder
            .Property(a => a.TickerSymbol)
            .IsRequired()
            .HasMaxLength(MaxTickerSymbolLength);

        builder
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(MaxNameLength);

        builder
            .Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(MaxDescriptionLength);

        builder
            .Property(a => a.MarketPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Asset_TickerSymbol", $"LEN([TickerSymbol]) >= {MinTickerSymbolLength}");
            t.HasCheckConstraint("CK_Asset_Name", $"LEN([Name]) >= {MinNameLength}");
            t.HasCheckConstraint("CK_Asset_Description", $"LEN([Description]) >= {MinDescriptionLength}");
            t.HasCheckConstraint("CK_Asset_MarketPrice", "[MarketPrice] > 0");
        });
    }
}
