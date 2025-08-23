using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using LiteBus.Commands.Abstractions;
using LiteBus.Messaging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Update
{
    public class UpdateAssetCommandHandler : ICommandHandler<UpdateAssetCommand, Result>
    {
        private readonly IAssetRepository _assetRepository;

        public UpdateAssetCommandHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        async Task<Result> IAsyncMessageHandler<UpdateAssetCommand, Result>.HandleAsync(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = await this._assetRepository.GetById(request.Id, cancellationToken);

            if (asset == null)
            {
                return Result.Failure(new[] { "Asset not found!" }); 
            }

            asset
                .UpdateTickerSymbol(request.TickerSymbol)
                .UpdateDescription(request.Description)
                .UpdateName(request.Name)
                .UpdateMarketPrice(request.MarketPrice);

            await _assetRepository.UpdateAsync(asset, cancellationToken);

            return Result.Success;
        }
    }
}
