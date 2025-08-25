namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;

public class AssetCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string TickerSymbol { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal MarketPrice { get; set; }
}
