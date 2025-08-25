using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Domain.Factories.Assets;

public class AssetFactory : IAssetFactory
{
    private AssetType _assetType = default;
    private string _tickerSymbol = default;
    private string _name = default;
    private string _description = default;
    private decimal _marketPrice = default;

    private bool _assetTypeSet = false;
    private bool _tickerSymbolSet = false;
    private bool _nameSet = false;
    private bool _descriptionSet = false;
    private bool _marketPriceSet = false;

    public AssetFactory WithAssetType(AssetType assetType)
    {
        _assetType = assetType;
        _assetTypeSet = true;
        return this;
    }

    public AssetFactory WithTickerSymbol(string tickerSymbol)
    {
        _tickerSymbol = tickerSymbol;
        _tickerSymbolSet = true;
        return this;
    }

    public AssetFactory WithName(string name)
    {
        _name = name;
        _nameSet = true;
        return this;
    }

    public AssetFactory WithDescription(string description)
    {
        _description = description;
        _descriptionSet = true;
        return this;
    }

    public AssetFactory WithMarketPrice(decimal marketPrice)
    {
        _marketPrice = marketPrice;
        _marketPriceSet = true;
        return this;
    }

    public Asset Build()
    {
        if (!_assetTypeSet || !_tickerSymbolSet || !_nameSet || !_descriptionSet || !_marketPriceSet)
        {
            throw new InvalidAssetException(
                $"{nameof(_assetType)}, " +
                $"{nameof(_tickerSymbol)}, " +
                $"{nameof(_name)}, " +
                $"{nameof(_description)} " +
                $"and {nameof(_marketPrice)} must have a value.");
        }

        return new Asset(
            _assetType,
            _tickerSymbol,
            _name,
            _description,
            _marketPrice);
    }
}
