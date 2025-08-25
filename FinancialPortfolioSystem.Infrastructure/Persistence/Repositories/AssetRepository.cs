using FinancialPortfolioSystem.Application.Features.Assets;
using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Models.Assets;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Repositories;

internal class AssetRepository(IMapper mapper, FinancePortfolioDbContext db) : IAssetRepository
{
    private readonly IMapper _mapper = mapper;
    private readonly FinancePortfolioDbContext _db = db;

    public async Task<AllAssetsOutputModel> GetAllAsync(Expression<Func<Asset,bool>> func = null, CancellationToken cancellationToken = default)
    {
        var dataModels = func is null
            ? await _db.Assets.AsNoTracking().ToListAsync(cancellationToken)
            : await _db.Assets.AsNoTracking().Where(func).ToListAsync(cancellationToken);
        var items = _mapper.Map<List<AssetDetailedOutputModel>>(dataModels);
        return new AllAssetsOutputModel
        {
            Items = items,
            Count = items.Count
        };
    }

    public async Task<Asset> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _db.Assets.Where(a => a.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task CreateAsync(Asset asset, CancellationToken cancellationToken = default)
    {
        await _db.Assets.AddAsync(asset);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Asset asset, CancellationToken cancellationToken = default)
    {
        _db.Assets.Update(asset);

        await _db.SaveChangesAsync(cancellationToken);
    }
}
