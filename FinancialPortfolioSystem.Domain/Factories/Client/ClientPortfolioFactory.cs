using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Factories.Assets;
using FinancialPortfolioSystem.Domain.Models.Assets;
using FinancialPortfolioSystem.Domain.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Factories.Client
{
    public class ClientPortfolioFactory : IFactory<ClientPortfolio>
    {
        private int clientId = default;

        private bool clientIdSet = false;

        public ClientPortfolioFactory WithClientId(int clientId)
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
}
