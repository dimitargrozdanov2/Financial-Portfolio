using FinancialPortfolioSystem.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialPortfolioSystem.Infrastructure.Persistence;

internal class PortfolioDbInitializer : IPortfolioDbInitializer
{
    private readonly FinancePortfolioDbContext _db;
    private readonly IEnumerable<IInitialData> _initialDataProviders;

    public PortfolioDbInitializer(
        FinancePortfolioDbContext db, IEnumerable<IInitialData> initialDataProviders)
    {
        _db = db;
        _initialDataProviders = initialDataProviders;
    }

    public void Initialize()
    {
        _db.Database.Migrate();

        foreach (var initialDataProvider in _initialDataProviders)
        {
            if (IsDataSetEmpty(initialDataProvider.EntityType))
            {
                var data = initialDataProvider.SeedData();

                foreach (var entity in data)
                {
                    _db.Add(entity);
                }
            }
        }

        _db.SaveChanges();
    }

    private bool IsDataSetEmpty(Type type)
    {
        var setMethod = GetType()
            .GetMethod(nameof(GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
            .MakeGenericMethod(type);

        var set = setMethod.Invoke(this, Array.Empty<object>());

        var countMethod = typeof(Queryable)
            .GetMethods()
            .First(m => m.Name == nameof(Queryable.Count) && m.GetParameters().Length == 1)
            .MakeGenericMethod(type);

        var result = (int)countMethod.Invoke(null, new[] { set })!;

        return result == 0;
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class
        => _db.Set<TEntity>();
}
