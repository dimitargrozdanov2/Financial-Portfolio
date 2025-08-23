using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Repositories
{
    internal class AssetRepository : IAssetRepository
    {
        private readonly IMapper _mapper;
        private readonly FinancePortfolioDbContext _data;

        public AssetRepository(IMapper mapper, FinancePortfolioDbContext db)
        {
            _mapper = mapper;
            _data = db;
        }

        public async Task<AllAssetsOutputModel> GetAll(Expression<Func<Asset,bool>> func = default, CancellationToken cancellationToken = default)
        {
            var dataModels = await _data.Assets.Where(func).ToListAsync(cancellationToken);
            var items = _mapper.Map<List<AssetDetailedOutputModel>>(dataModels);
            return new AllAssetsOutputModel
            {
                Items = items,
                Count = items.Count
            };
        }

        public async Task<Asset> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _data.Assets.Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task CreateAsync(Asset asset, CancellationToken cancellationToken = default)
        {
            await _data.Assets.AddAsync(asset);

            await _data.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Asset asset, CancellationToken cancellationToken = default)
        {
            _data.Assets.Update(asset);

            await _data.SaveChangesAsync(cancellationToken);
        }
    }
}
