using LiteBus.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll
{
    public class GetAllAssetsQueryHandler : IQueryHandler<GetAllAssetsQuery, AllAssetsOutputModel>
    {
        private readonly IAssetRepository _assetRepository;

        public GetAllAssetsQueryHandler(IAssetRepository assetRepository)
        {
            this._assetRepository = assetRepository;
        }

        public async Task<AllAssetsOutputModel> HandleAsync(GetAllAssetsQuery message, CancellationToken cancellationToken = default)
        {
            return await this._assetRepository.GetAll();
        }
    }
}
