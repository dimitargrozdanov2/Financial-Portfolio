using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;

public class AssetDetailedOutputModel
{
    public int Id { get; set; }
    public AssetType AssetType { get; set; }
    public string TickerSymbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal MarketPrice { get; set; }
}
