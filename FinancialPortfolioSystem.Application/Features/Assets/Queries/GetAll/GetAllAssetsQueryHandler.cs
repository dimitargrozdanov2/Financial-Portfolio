using LiteBus.Queries.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;

public class GetAllAssetsQueryHandler : IQueryHandler<GetAllAssetsQuery, AllAssetsOutputModel>
{
    private readonly IAssetRepository _assetRepository;

    public GetAllAssetsQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<AllAssetsOutputModel> HandleAsync(GetAllAssetsQuery message, CancellationToken cancellationToken = default)
    {
        return await _assetRepository.GetAll(a => !a.IsDeleted);
    }
}
