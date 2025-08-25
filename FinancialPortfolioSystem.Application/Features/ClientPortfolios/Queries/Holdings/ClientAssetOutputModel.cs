namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings;

public class ClientAssetOutputModel
{
    public int Id { get; set; }

    public int AssetId { get; set; }
    public int Quantity { get; set; }

    public string AssetName { get; set; }

    public string AssetTickerSymbol { get; set; }

    public decimal MarketPrice { get; set; }

    public decimal AssetTotalValue { get; set; }
}
