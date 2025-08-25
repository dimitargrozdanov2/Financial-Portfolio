using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FinancialPortfolioSystem.Application.Features.Identity;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Commands.SellAsset;

internal class SellClientAssetCommandHandler : ICommandHandler<SellClientAssetCommand, Result>
{
    private readonly IClientPortfolioRepository _clientPortfolioRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly ICurrentUser _currentUser;

    public SellClientAssetCommandHandler(
        IClientPortfolioRepository clientPortfolioRepository,
        IAssetRepository assetRepository,
        ICurrentUser currentUser)
    {
        _clientPortfolioRepository = clientPortfolioRepository;
        _assetRepository = assetRepository;
        _currentUser = currentUser;
    }

    public async Task<Result> HandleAsync(SellClientAssetCommand request, CancellationToken cancellationToken = default)
    {
        List<string> errors = new List<string>();
        var asset = await _assetRepository.GetById(request.AssetId, cancellationToken);

        if (asset == null)
        {
            errors.Add("Asset not found!");
        }

        var portfolio = await _clientPortfolioRepository.GetByUserId(_currentUser.UserId);

        if (portfolio == null)
        {
            errors.Add("Portfolio not found!");
        }

        var clientAsset = portfolio.ClientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id);
        if (clientAsset == null)
        {
            errors.Add("Unable to sell asset that does not exist in the portfolio!");
        }

        if (errors.Count != 0)
        {
            return Result.Failure(errors.ToArray());
        }

        portfolio.SellAsset(asset, request.Quantity, asset.MarketPrice);

        await _clientPortfolioRepository.UpdateAsync(portfolio);

        return Result.Success;
    }
}
