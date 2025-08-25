using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Assets;

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

    public string TickerSymbol { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal MarketPrice { get; private set; }

    public bool IsDeleted { get; private set; }

    public Asset UpdateTickerSymbol(string tickerSymbol)
    {
        this.ValidateTickerSymbol(tickerSymbol);
        this.TickerSymbol = tickerSymbol;
        return this;
    }

    public Asset UpdateName(string name)
    {
        this.ValidateName(name);
        this.Name = name;
        return this;
    }

    public Asset UpdateDescription(string description)
    {
        this.ValidateDescription(description);
        this.Description = description;
        return this;
    }

    public Asset UpdateMarketPrice(decimal marketPrice)
    {
        this.ValidateMarketPrice(marketPrice);
        this.MarketPrice = marketPrice;
        return this;
    }

    private void Validate(AssetType assetType, string tickerSymbol, string name, string description, decimal marketPrice)
    {
        ValidateAssetType(assetType);
        ValidateTickerSymbol(tickerSymbol);
        ValidateName(name);
        ValidateDescription(description);
        ValidateMarketPrice(marketPrice);
   }

    private void ValidateAssetType(AssetType assetType)
    {
        Guard.AgainstDefault<InvalidAssetException>(
            assetType,
            nameof(this.AssetType));
    }

    private void ValidateTickerSymbol(string tickerSymbol)
    {
        Guard.ForStringLength<InvalidAssetException>(
            tickerSymbol,
            MinTickerSymbolLength,
            MaxTickerSymbolLength,
            nameof(this.TickerSymbol));
    }

    private void ValidateName(string name)
    {
        Guard.ForStringLength<InvalidAssetException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));
    }

    private void ValidateDescription(string description)
    {
        Guard.ForStringLength<InvalidAssetException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
    }

    private void ValidateMarketPrice(decimal marketPrice)
    {
        Guard.AgainstZeroOrNegative<InvalidAssetException>(
            marketPrice,
            nameof(this.MarketPrice));
    }

    public void MarkAsDeleted() => IsDeleted = true;

}
