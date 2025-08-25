using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;

public class CreateAssetCommand : AssetCommand<CreateAssetCommand>, ICommand<CreatedAssetOutputModel>
{
    public int AssetType { get; set; }
}
