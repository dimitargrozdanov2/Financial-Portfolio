using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset
{
    public class SellClientAssetCommand : ClientAssetCommand<SellClientAssetCommand>, ICommand<Result>
    {
    }
}
