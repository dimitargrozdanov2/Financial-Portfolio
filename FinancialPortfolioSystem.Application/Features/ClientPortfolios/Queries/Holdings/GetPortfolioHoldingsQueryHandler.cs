using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Application.Features.Identity;
using FinancialPortfolioSystem.Domain.Factories.Client;
using LiteBus.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings
{
    internal class GetPortfolioHoldingsQueryHandler : IQueryHandler<GetPortfolioHoldingsQuery, AllClientAssetsOutputModel>
    {
        private readonly IClientPortfolioRepository _clientPortfolioRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly ICurrentUser _currentUser;

        public GetPortfolioHoldingsQueryHandler(
            IClientPortfolioRepository clientPortfolioRepository, 
            IAssetRepository assetRepository, 
            ICurrentUser currentUser)
        {
            _clientPortfolioRepository = clientPortfolioRepository;
            _assetRepository = assetRepository;
            _currentUser = currentUser;
        }

        public async Task<AllClientAssetsOutputModel> HandleAsync(GetPortfolioHoldingsQuery request, CancellationToken cancellationToken = default)
        {
            var portfolio = await _clientPortfolioRepository.GetByUserId(_currentUser.UserId);
            var emptyResponse = new AllClientAssetsOutputModel()
            {
                Items = new List<ClientAssetOutputModel>(),
                TotalValue = 0
            };
            if (portfolio == null)
            {
                return emptyResponse;
            }
            else
            {
                var clientAssets = portfolio.ClientAssets;
                var clientAssetsIds = clientAssets.Select(x => x.AssetId);
                var assetsMetaData = await _assetRepository
                    .GetAll(x => clientAssetsIds.Contains(x.Id), cancellationToken);
                var assets = assetsMetaData.Items;
                foreach (var clientAsset in clientAssets)
                {
                    ClientAssetOutputModel clientAssetOutputModel = new ClientAssetOutputModel();
                    clientAssetOutputModel.Id = clientAsset.Id;
                    clientAssetOutputModel.AssetId = clientAsset.AssetId;
                    clientAssetOutputModel.Quantity = clientAsset.Quantity;
                    var asset = assets.FirstOrDefault(x => x.Id == clientAsset.AssetId);
                    clientAssetOutputModel.MarketPrice = asset.MarketPrice;
                    clientAssetOutputModel.AssetTickerSymbol = asset.TickerSymbol;
                    clientAssetOutputModel.AssetName = asset.Name;
                    clientAssetOutputModel.AssetTotalValue = clientAssetOutputModel.MarketPrice * clientAssetOutputModel.Quantity;
                    emptyResponse.Items.Add(clientAssetOutputModel);
                    emptyResponse.TotalValue += clientAssetOutputModel.AssetTotalValue;
                }
                return emptyResponse;
            }
        }
    }
}
