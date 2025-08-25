using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Transaction;

namespace FinancialPortfolioSystem.Domain.Models.Client;

public class ClientTransaction : Entity<int>
{
    internal ClientTransaction(int assetId, ClientTransactionType type, int quantity, decimal pricePerUnit)
    {
        Validate(type, quantity, pricePerUnit);

        AssetId = assetId;
        Type = type;
        Quantity = quantity;
        PricePerUnit = pricePerUnit;
        Timestamp = DateTime.UtcNow;
    }

    public int AssetId { get; private set; }
    public ClientTransactionType Type { get; private set; }
    public int Quantity { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public DateTime Timestamp { get; private set; }

    private void Validate(ClientTransactionType type, int quantity, decimal pricePerUnit)
    {
        Guard.AgainstDefault<InvalidClientTransactionException>(
            type,
            nameof(Type));

        Guard.AgainstOutOfRange<InvalidClientTransactionException>(
            quantity,
            MinTransactionQuantity,
            int.MaxValue,
            nameof(quantity));

        Guard.AgainstZeroOrNegative<InvalidClientTransactionException>(
            pricePerUnit,
            nameof(pricePerUnit));
    }
}


