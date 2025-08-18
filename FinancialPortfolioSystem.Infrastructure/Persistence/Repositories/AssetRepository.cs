using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Repositories
{
    internal class AssetRepository : IAssetRepository
    {
        private readonly IMapper _mapper;
        private readonly FinancePortfolioDbContext _data;

        public AssetRepository(IMapper mapper, FinancePortfolioDbContext db)
        {
            this._mapper = mapper;
            this._data = db;
        }

        public async Task<AllAssetsOutputModel> GetAll(CancellationToken cancellationToken = default)
        {
            var dataModels = await this._data.Assets.ToListAsync(cancellationToken);
            var x = _mapper.Adapt<List<AssetOutputModel>>(); //to test
            var items = dataModels.Adapt<List<AssetOutputModel>>();
            return new AllAssetsOutputModel
            {
                Items = items,
                Count = items.Count
            };
        }

        public async Task Create(Asset asset, CancellationToken cancellationToken = default)
        {
            await this._data.Assets.AddAsync(asset); //need to add model of database

            await this._data.SaveChangesAsync(cancellationToken);
        }
    }
}
