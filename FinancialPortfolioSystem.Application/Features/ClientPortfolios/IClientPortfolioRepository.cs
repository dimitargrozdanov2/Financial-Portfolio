using FinancialPortfolioSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios
{
    public interface IClientPortfolioRepository : IAggregateRoot
    {
        Task<FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio> GetByUserId(string id, CancellationToken cancellationToken = default);
        Task CreateAsync(FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default);
        Task UpdateAsync(FinancialPortfolioSystem.Domain.Models.Client.ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default);
    }
}
