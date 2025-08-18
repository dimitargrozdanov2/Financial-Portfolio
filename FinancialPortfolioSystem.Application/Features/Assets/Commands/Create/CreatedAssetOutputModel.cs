namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create
{
    public class CreatedAssetOutputModel
    {
        public CreatedAssetOutputModel(int assetId) => this.AssetId = assetId;

        public int AssetId { get; }
    }
}
