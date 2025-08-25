using FinancialPortfolioSystem.Domain.Common;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios
{
    public interface IClientPortfolioRepository : IAggregateRoot
    {
        Task<FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio> GetByUserIdAsync(string id, CancellationToken cancellationToken = default);
        Task CreateAsync(FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default);
        Task UpdateAsync(FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default);
    }
}
