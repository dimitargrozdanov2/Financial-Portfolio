using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios;
using FinancialPortfolioSystem.Application.Features.Identity;
using FinancialPortfolioSystem.Domain.Factories.Client;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;

public class BuyClientAssetCommandHandler : ICommandHandler<BuyClientAssetCommand, Result>
{
    private readonly IClientPortfolioRepository _clientPortfolioRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly IClientPortfolioFactory _clientPortfolioFactory;
    private readonly ICurrentUser _currentUser;

    public BuyClientAssetCommandHandler(
        IClientPortfolioRepository clientPortfolioRepository,
        IAssetRepository assetRepository,
        IClientPortfolioFactory clientPortfolioFactory,
        ICurrentUser currentUser)
    {
        _clientPortfolioRepository = clientPortfolioRepository;
        _assetRepository = assetRepository;
        _clientPortfolioFactory = clientPortfolioFactory;
        _currentUser = currentUser;
    }

    public async Task<Result> HandleAsync(BuyClientAssetCommand request, CancellationToken cancellationToken = default)
    {
        var asset = await this._assetRepository.GetById(request.AssetId, cancellationToken);

        if (asset == null)
        {
            return Result.Failure(new[] { "Asset not found!" });
        }

        var portfolio = await _clientPortfolioRepository.GetByUserId(_currentUser.UserId);

        if (portfolio == null)
        {
            portfolio = _clientPortfolioFactory
                .WithClientId(_currentUser.UserId)
                .Build();

            portfolio.BuyAsset(asset, request.Quantity, asset.MarketPrice);

            await _clientPortfolioRepository.CreateAsync(portfolio);
        }
        else
        {
            portfolio.BuyAsset(asset, request.Quantity, asset.MarketPrice);

            await _clientPortfolioRepository.UpdateAsync(portfolio);
        }

        return Result.Success;
    }
}
