namespace FinancialPortfolioSystem.Domain.Common;

public interface IInitialData
{
    Type EntityType { get; }

    IEnumerable<object> SeedData();
}
