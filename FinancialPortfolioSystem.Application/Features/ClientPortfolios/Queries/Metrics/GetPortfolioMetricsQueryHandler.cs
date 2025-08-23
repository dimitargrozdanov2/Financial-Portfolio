using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings;
using FinancialPortfolioSystem.Application.Features.Identity;
using LiteBus.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Metrics
{
    internal class GetPortfolioMetricsQueryHandler : IQueryHandler<GetPortfolioMetricsQuery, PortfolioMetricsOutputModel>
    {
        private readonly IClientPortfolioRepository _clientPortfolioRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly ICurrentUser _currentUser;

        public GetPortfolioMetricsQueryHandler(
            IClientPortfolioRepository clientPortfolioRepository,
            IAssetRepository assetRepository,
            ICurrentUser currentUser)
        {
            _clientPortfolioRepository = clientPortfolioRepository;
            _assetRepository = assetRepository;
            _currentUser = currentUser;
        }

        public async Task<PortfolioMetricsOutputModel> HandleAsync(GetPortfolioMetricsQuery message, CancellationToken cancellationToken = default)
        {
            var portfolio = await _clientPortfolioRepository.GetByUserId(_currentUser.UserId);
            var emptyResponse = new PortfolioMetricsOutputModel()
            {
                CurrentMarketValue = 0,
                TotalInvestedAmount = 0,
                ROI = "0"
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
                    emptyResponse.TotalInvestedAmount += clientAsset.Quantity * clientAsset.AverageCost;
                }
                foreach (var asset in assets)
                {
                    emptyResponse.CurrentMarketValue += asset.MarketPrice * clientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id).Quantity;
                }
                emptyResponse.ROI =
                    ((emptyResponse.CurrentMarketValue - emptyResponse.TotalInvestedAmount) * 100
                    / (emptyResponse.TotalInvestedAmount)).ToString("0.##");

                return emptyResponse;
            }
        }
    }
}
