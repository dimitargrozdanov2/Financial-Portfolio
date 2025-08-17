using FinancialPortfolioSystem.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinancialPortfolioSystem.Infrastructure.Persistence
{
    internal class PortfolioDbInitializer : IPortfolioDbInitializer
    {
        private readonly FinancePortfolioDbContext db;
        private readonly IEnumerable<IInitialData> initialDataProviders;

        public PortfolioDbInitializer(
            FinancePortfolioDbContext db, IEnumerable<IInitialData> initialDataProviders)
        {
            this.db = db;
            this.initialDataProviders = initialDataProviders;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            foreach (var initialDataProvider in this.initialDataProviders)
            {
                if (this.IsDataSetEmpty(initialDataProvider.EntityType))
                {
                    var data = initialDataProvider.SeedData();

                    foreach (var entity in data)
                    {
                        this.db.Add(entity);
                    }
                }
            }

            this.db.SaveChanges();
        }

        private bool IsDataSetEmpty(Type type)
        {
            var setMethod = this.GetType()
                .GetMethod(nameof(this.GetSet), BindingFlags.Instance | BindingFlags.NonPublic)!
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
            => this.db.Set<TEntity>();
    }
}
