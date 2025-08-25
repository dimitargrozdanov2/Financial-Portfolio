namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;

public class AllAssetsOutputModel
{
    public List<AssetDetailedOutputModel> Items { get; set; }

    public int Count { get; set; }
}
