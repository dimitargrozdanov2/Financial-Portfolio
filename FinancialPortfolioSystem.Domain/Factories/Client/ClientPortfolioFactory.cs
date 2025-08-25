using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Client;

namespace FinancialPortfolioSystem.Domain.Factories.Client;

public class ClientPortfolioFactory : IClientPortfolioFactory
{
    private string _clientId = default;

    private bool _clientIdSet = false;

    public ClientPortfolioFactory WithClientId(string clientId)
    {
        _clientId = clientId;
        _clientIdSet = true;
        return this;
    }

    public ClientPortfolio Build()
    {
        if (!_clientIdSet)
        {
            throw new InvalidClientPortfolioException(
                $"{nameof(_clientId)} must have a value.");
        }

        return new ClientPortfolio(_clientId);
    }
}
