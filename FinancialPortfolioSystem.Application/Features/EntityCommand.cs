namespace FinancialPortfolioSystem.Application.Features;

public class EntityCommand<TId>
{
    internal TId Id { get; set; } = default;
}
