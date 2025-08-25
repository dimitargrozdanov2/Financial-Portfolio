using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Delete;

internal class DeleteAssetCommandHandler : ICommandHandler<DeleteAssetCommand, Result>
{
    private readonly IAssetRepository _assetRepository;

    public DeleteAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<Result> HandleAsync(DeleteAssetCommand request, CancellationToken cancellationToken = default)
    {
        var asset = await _assetRepository.GetByIdAsync(request.Id, cancellationToken);

        if (asset == null)
        {
            return Result.Failure(new[] { "Asset not found!" });
        }

        asset.MarkAsDeleted();
        await _assetRepository.UpdateAsync(asset, cancellationToken);
        return Result.Success;
    }
}
