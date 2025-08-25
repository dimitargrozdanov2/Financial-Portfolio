namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;

public class CreatedAssetOutputModel(int assetId)
{
    public int AssetId { get; } = assetId;
}
