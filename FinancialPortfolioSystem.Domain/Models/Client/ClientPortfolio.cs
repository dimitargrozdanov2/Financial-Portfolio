using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client
{
    public class ClientPortfolio : Entity<Guid>, IAggregateRoot
    {
        private readonly HashSet<ClientAsset> _clientAssets = new HashSet<ClientAsset>();
        private readonly List<ClientTransaction> _clientTransactions = new List<ClientTransaction>(); // we may need them in order

        private ClientPortfolio(Guid clientId)
        {
            ClientId = clientId;
        }

        public IReadOnlyCollection<ClientAsset> ClientAssets => _clientAssets.ToList().AsReadOnly();
        public IReadOnlyCollection<ClientTransaction> Transactions => _clientTransactions.ToList().AsReadOnly();
        public Guid ClientId { get; private set; }

        public static ClientPortfolio CreateNew(Guid clientId)
        {
            return new ClientPortfolio(clientId);
        }

        internal void BuyAsset(Asset asset, int quantity, decimal pricePerUnit)
        {
            Guard.AgainstOutOfRange<InvalidAssetException>(
                quantity,
                Zero,
                int.MaxValue,
                nameof(quantity));

            var clientTransaction = new ClientTransaction(asset.Id, ClientTransactionType.Buy, quantity,  pricePerUnit, DateTime.UtcNow);
            _clientTransactions.Add(clientTransaction);

            var clientAsset = _clientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id);
            if (clientAsset == null)
            {
                clientAsset = new ClientAsset(asset.Id, 0, new Currency(asset.MarketPriceCurrency.Name, 0));
                _clientAssets.Add(clientAsset);
            }

            clientAsset.ApplyTransaction(clientTransaction);
        }

        internal void SellAsset(Asset asset, int quantity, decimal pricePerUnit)
        {
            Guard.AgainstOutOfRange<InvalidClientPortfolioException>(
                quantity,
                Zero,
                int.MaxValue,
                nameof(quantity));

            var clientAsset = _clientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id);
            if (clientAsset == null)
            {
                throw new InvalidClientPortfolioException("There is no asset to be sold!");
            }

            if (clientAsset.Quantity - quantity < 0)
            {
                throw new InvalidClientPortfolioException($"Cannot sell more than {clientAsset.Quantity} units of stock!");
            }

            var clientTransaction = new ClientTransaction(asset.Id, ClientTransactionType.Sell, quantity, pricePerUnit, DateTime.UtcNow);
            clientAsset.ApplyTransaction(clientTransaction);

            _clientTransactions.Add(clientTransaction);
        }
    }
}
