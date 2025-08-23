using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset
{
    public class BuyClientAssetCommand : ClientAssetCommand<BuyClientAssetCommand>, ICommand<Result>
    {
    }
}
