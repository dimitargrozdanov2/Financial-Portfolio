using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Domain.Factories.Assets
{
    internal class AssetFactory : IAssetFactory
    {
        private AssetType assetType = default;
        private string tickerSymbol = default;
        private string name = default;
        private string description = default;
        private decimal marketPrice = default;

        private bool assetTypeSet = false;
        private bool tickerSymbolSet = false;
        private bool nameSet = false;
        private bool descriptionSet = false;
        private bool marketPriceSet = false;

        public AssetFactory WithAssetType(AssetType assetType)
        {
            this.assetType = assetType;
            this.assetTypeSet = true;
            return this;
        }

        public AssetFactory WithTickerSymbol(string tickerSymbol)
        {
            this.tickerSymbol = tickerSymbol;
            this.tickerSymbolSet = true;
            return this;
        }

        public AssetFactory WithName(string name)
        {
            this.name = name;
            this.nameSet = true;
            return this;
        }

        public AssetFactory WithDescription(string description)
        {
            this.description = description;
            this.descriptionSet = true;
            return this;
        }

        public AssetFactory WithMarketPrice(decimal marketPrice)
        {
            this.marketPrice = marketPrice;
            this.marketPriceSet = true;
            return this;
        }

        public Asset Build()
        {
            if (!this.assetTypeSet || !this.tickerSymbolSet || !this.nameSet || this.descriptionSet || this.marketPriceSet)
            {
                throw new InvalidAssetException(
                    $"{nameof(this.assetType)}, " +
                    $"{nameof(this.tickerSymbol)}, " +
                    $"{nameof(this.name)}, " +
                    $"{nameof(this.description)} " +
                    $"and {nameof(this.marketPrice)} must have a value.");
            }

            return new Asset(
                this.assetType,
                this.tickerSymbol,
                this.name,
                this.description,
                this.marketPrice);
        }
    }
}
