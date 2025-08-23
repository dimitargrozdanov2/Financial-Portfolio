using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Update;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Delete
{
    internal class DeleteAssetCommandHandler : ICommandHandler<DeleteAssetCommand, Result>
    {
        private readonly IAssetRepository _assetRepository;

        public DeleteAssetCommandHandler(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<Result> HandleAsync(DeleteAssetCommand request, CancellationToken cancellationToken = default)
        {
            var asset = await this._assetRepository.GetById(request.Id, cancellationToken);

            if (asset == null)
            {
                return Result.Failure(new[] { "Asset not found!" });
            }

            asset.MarkAsDeleted();
            await _assetRepository.UpdateAsync(asset, cancellationToken);
            return Result.Success;
        }
    }
}
