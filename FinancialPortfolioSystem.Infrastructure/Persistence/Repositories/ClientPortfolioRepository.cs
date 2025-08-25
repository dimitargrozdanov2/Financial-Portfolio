using FinancialPortfolioSystem.Application.Features.ClientPortfolios;
using FinancialPortfolioSystem.Domain.Models.Client;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolioSystem.Infrastructure.Persistence.Repositories;

internal class ClientPortfolioRepository(FinancePortfolioDbContext db) : IClientPortfolioRepository
{
    private readonly FinancePortfolioDbContext _data = db;

    public async Task<ClientPortfolio> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await _data.ClientPortfolios
            .Include(cp => cp.ClientAssets)
            .Where(a => a.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task CreateAsync(ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default)
    {
        await _data.ClientPortfolios.AddAsync(clientPortfolio);

        await _data.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(ClientPortfolio clientPortfolio, CancellationToken cancellationToken = default)
    {
        _data.ClientPortfolios.Update(clientPortfolio);

        await _data.SaveChangesAsync(cancellationToken);
    }
}
