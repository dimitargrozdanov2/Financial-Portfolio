using FinancialPortfolioSystem.Domain.Common;

namespace FinancialPortfolioSystem.Domain.Factories;

public interface IFactory<out TEntity>
    where TEntity : IAggregateRoot
{
    TEntity Build();
}
