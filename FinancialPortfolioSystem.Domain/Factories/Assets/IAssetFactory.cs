using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Domain.Factories.Assets;

public interface IAssetFactory : IFactory<Asset>
{
    AssetFactory WithAssetType(AssetType assetType);
    AssetFactory WithDescription(string description);
    AssetFactory WithMarketPrice(decimal marketPrice);
    AssetFactory WithName(string name);
    AssetFactory WithTickerSymbol(string tickerSymbol);
}