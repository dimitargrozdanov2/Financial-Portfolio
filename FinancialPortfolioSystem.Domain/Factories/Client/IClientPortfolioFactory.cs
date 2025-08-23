using FinancialPortfolioSystem.Domain.Models.Client;

namespace FinancialPortfolioSystem.Domain.Factories.Client
{
    public interface IClientPortfolioFactory : IFactory<ClientPortfolio>
    {
        ClientPortfolioFactory WithClientId(string clientId);
    }
}