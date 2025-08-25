using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Delete;

public class DeleteAssetCommand : EntityCommand<int>, ICommand<Result>
{
}
