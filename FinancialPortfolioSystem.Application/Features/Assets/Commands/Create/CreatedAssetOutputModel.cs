using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create
{
    public class CreatedAssetOutputModel(int assetId) //primary constructor
    {
        public int AssetId { get; } = assetId;
    }
}
