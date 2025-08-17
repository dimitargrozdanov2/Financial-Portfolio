using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client
{
    public class ClientAsset : ValueObject
    {
        internal ClientAsset(Guid assetId, int quantity, Currency totalAmountPaid)
        {
            Validate(quantity, totalAmountPaid);

            this.AssetId = assetId;
            this.Quantity = quantity;
            this.TotalAmountPaid = totalAmountPaid;
        }

        public Guid AssetId { get; }
        public int Quantity { get; private set; }
        public Currency TotalAmountPaid { get; private set; }

        private void Validate(int quantity, Currency totalAmountPaid)
        {
            Guard.AgainstOutOfRange<InvalidClientAssetException>(
                quantity,
                Zero,
                int.MaxValue,
                nameof(this.Quantity));
        }

        internal void ApplyTransaction(ClientTransaction transaction)
        {
            if (transaction.Type.Equals(ClientTransactionType.Buy))
            {
                Quantity += transaction.Quantity; //test to see if transaction parameters are populated
                TotalAmountPaid.IncreaseBy(transaction.Quantity * transaction.PricePerUnit);
            }
            else if (transaction.Type.Equals(ClientTransactionType.Sell))
            {
                Quantity -= transaction.Quantity;
                TotalAmountPaid.DecreaseBy(transaction.Quantity * transaction.PricePerUnit);
            }
        }
    }
}
