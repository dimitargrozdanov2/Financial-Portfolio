using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Assets
{
    public class Asset : Entity<int>, IAggregateRoot
    {
        internal Asset(AssetType assetType, string tickerSymbol, string name, string description, decimal marketPrice)
        {
            this.Validate(assetType, tickerSymbol, name, description, marketPrice);

            this.AssetType = assetType;
            this.TickerSymbol = tickerSymbol;
            this.Name = name;
            this.Description = description;
            this.MarketPrice = marketPrice;
        }

        public AssetType AssetType { get; }

        public string TickerSymbol { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal MarketPrice { get; }

        private void Validate(AssetType assetType, string tickerSymbol, string name, string description, decimal marketPrice)
        {
            Guard.AgainstDefault<InvalidAssetException>(
                assetType,
                nameof(this.AssetType));

            Guard.ForStringLength<InvalidAssetException>(
                tickerSymbol,
                MinTickerSymbolLength,
                MaxTickerSymbolLength,
                nameof(this.TickerSymbol));

            Guard.ForStringLength<InvalidAssetException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidAssetException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

            Guard.AgainstZeroOrNegative<InvalidAssetException>(
                marketPrice,
                nameof(this.MarketPrice));
       }
    }
}
