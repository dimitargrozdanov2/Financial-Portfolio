namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings;

public class AllClientAssetsOutputModel
{
    public List<ClientAssetOutputModel> Items { get; set; }

    public decimal TotalValue { get; set; }
}
