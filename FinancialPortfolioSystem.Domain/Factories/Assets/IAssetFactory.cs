using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Domain.Factories.Assets
{
    internal interface IAssetFactory : IFactory<Asset>
    {
        AssetFactory WithAssetType(AssetType assetType);
        AssetFactory WithDescription(string description);
        AssetFactory WithMarketPrice(Currency marketPrice);
        AssetFactory WithName(string name);
        AssetFactory WithTickerSymbol(string tickerSymbol);
    }
}