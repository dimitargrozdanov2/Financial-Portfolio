using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client;

public class ClientAsset : Entity<int>
{
    internal ClientAsset(int assetId, int quantity, decimal averageCost)
    {
        Validate(quantity, averageCost);

        this.AssetId = assetId;
        this.Quantity = quantity;
        this.AverageCost = averageCost;
    }

    public int AssetId { get; }
    public int Quantity { get; private set; }
    public decimal AverageCost { get; private set; }

    private void Validate(int quantity, decimal averageCost)
    {
        Guard.AgainstOutOfRange<InvalidClientAssetException>(
            quantity,
            Zero,
            int.MaxValue,
            nameof(this.Quantity));

        Guard.AgainstOutOfRange<InvalidClientAssetException>(
            averageCost,
            Zero,
            decimal.MaxValue,
            nameof(this.AverageCost));
    }

    internal void ApplyTransaction(ClientTransaction transaction)
    {
        if (transaction.Type.Equals(ClientTransactionType.Buy))
        {
            var totalCostBefore = Quantity * AverageCost;
            var totalCostAfter = totalCostBefore + (transaction.Quantity * transaction.PricePerUnit);
            Quantity += transaction.Quantity;
            AverageCost = totalCostAfter / Quantity;
        }
        else if (transaction.Type.Equals(ClientTransactionType.Sell))
        {
            Quantity -= transaction.Quantity;
            if (Quantity < 0)
            {
                throw new InvalidClientAssetException("You not allowed to sell more than you own!");
            }

            if (Quantity == 0)
            {
                AverageCost = 0;
            }
        }
    }
}
