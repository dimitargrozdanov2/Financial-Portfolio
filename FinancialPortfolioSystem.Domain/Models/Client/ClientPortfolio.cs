using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;

namespace FinancialPortfolioSystem.Domain.Models.Client;

public class ClientPortfolio : Entity<int>, IAggregateRoot
{
    private readonly HashSet<ClientAsset> _clientAssets = new HashSet<ClientAsset>();
    private readonly List<ClientTransaction> _clientTransactions = new List<ClientTransaction>(); // we may need them in order

    internal ClientPortfolio(string userId)
    {
        UserId = userId;
    }

    public IReadOnlyCollection<ClientAsset> ClientAssets => _clientAssets.ToList().AsReadOnly();
    public IReadOnlyCollection<ClientTransaction> Transactions => _clientTransactions.ToList().AsReadOnly();
    public string UserId { get; private set; }

    public void BuyAsset(Asset asset, int quantity, decimal pricePerUnit)
    {
        Validate(quantity, pricePerUnit);

        var clientTransaction = new ClientTransaction(asset.Id, ClientTransactionType.Buy, quantity,  pricePerUnit);
        _clientTransactions.Add(clientTransaction);

        var clientAsset = _clientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id);
        if (clientAsset == null)
        {
            clientAsset = new ClientAsset(asset.Id, clientTransaction.Quantity, clientTransaction.PricePerUnit);
            _clientAssets.Add(clientAsset);
        }
        else
        {
            clientAsset.ApplyTransaction(clientTransaction);
        }

    }

    public void SellAsset(Asset asset, int quantity, decimal pricePerUnit)
    {
        Validate(quantity, pricePerUnit);

        var clientAsset = _clientAssets.FirstOrDefault(ca => ca.AssetId == asset.Id);
        if (clientAsset == null)
        {
            throw new InvalidClientPortfolioException("There is no asset to be sold!");
        }

        if (clientAsset.Quantity - quantity < 0)
        {
            throw new InvalidClientPortfolioException($"Cannot sell more than {clientAsset.Quantity} units of stock!");
        }

        var clientTransaction = new ClientTransaction(asset.Id, ClientTransactionType.Sell, quantity, pricePerUnit);
        clientAsset.ApplyTransaction(clientTransaction);

        _clientTransactions.Add(clientTransaction);
    }

    private void Validate(int quantity, decimal pricePerUnit)
    {
        Guard.AgainstZeroOrNegative<InvalidClientPortfolioException>(
            quantity,
            nameof(quantity));

        Guard.AgainstZeroOrNegative<InvalidClientPortfolioException>(
            pricePerUnit,
            nameof(pricePerUnit));
    }
}
