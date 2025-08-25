namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;

public class ClientAssetCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public int AssetId { get; set; }
    public int Quantity { get; set; }
}
