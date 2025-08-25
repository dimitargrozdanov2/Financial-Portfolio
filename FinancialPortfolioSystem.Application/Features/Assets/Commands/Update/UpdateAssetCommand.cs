using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Update;

public class UpdateAssetCommand : AssetCommand<UpdateAssetCommand>, ICommand<Result>
{
}
