using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Factories.Assets;
using FinancialPortfolioSystem.Domain.Models.Assets;
using LiteBus.Commands.Abstractions;
using LiteBus.Messaging.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create
{
    public class CreateAssetCommandHandler : ICommandHandler<CreateAssetCommand, CreatedAssetOutputModel>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IAssetFactory _assetFactory;

        public CreateAssetCommandHandler(IAssetRepository assetRepository, IAssetFactory assetFactory)
        {
            _assetRepository = assetRepository;
            _assetFactory = assetFactory;
        }

        async Task<CreatedAssetOutputModel> IAsyncMessageHandler<CreateAssetCommand, CreatedAssetOutputModel>.HandleAsync(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = _assetFactory
                .WithAssetType(Enumeration.FromValue<AssetType>(request.AssetType))
                .WithTickerSymbol(request.TickerSymbol)
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithMarketPrice(request.MarketPrice)
                .Build();

            await this._assetRepository.Create(asset, cancellationToken);

            return new CreatedAssetOutputModel(asset.Id);
        }
    }
}
