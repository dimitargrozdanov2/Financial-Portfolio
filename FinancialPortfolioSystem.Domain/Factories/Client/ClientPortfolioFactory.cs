using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Client;

namespace FinancialPortfolioSystem.Domain.Factories.Client;

public class ClientPortfolioFactory : IClientPortfolioFactory
{
    private string clientId = default;

    private bool clientIdSet = false;

    public ClientPortfolioFactory WithClientId(string clientId)
    {
        this.clientId = clientId;
        this.clientIdSet = true;
        return this;
    }

    public ClientPortfolio Build()
    {
        if (!this.clientIdSet)
        {
            throw new InvalidClientPortfolioException(
                $"{nameof(this.clientId)} must have a value.");
        }

        return new ClientPortfolio(this.clientId);
    }
}
