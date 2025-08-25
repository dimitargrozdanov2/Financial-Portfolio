namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Metrics;

public class PortfolioMetricsOutputModel
{
    public decimal TotalInvestedAmount { get; set; }

    public decimal CurrentMarketValue { get; set; }

    public string ROI { get; set; }
}
