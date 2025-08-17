using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client
{
    public class ClientTransaction : Entity<Guid>
    {
        internal ClientTransaction(Guid assetId, ClientTransactionType type, int quantity, decimal pricePerUnit, DateTime timestamp)
        {
            this.Validate(quantity, pricePerUnit, timestamp);

            this.AssetId = assetId;
            this.Type = type;
            this.Quantity = quantity;
            this.PricePerUnit = pricePerUnit;
            this.Timestamp = timestamp;
        }

        public Guid AssetId { get; private set; }
        public ClientTransactionType Type { get; private set; }
        public int Quantity { get; private set; }
        public decimal PricePerUnit { get; private set; }
        public DateTime Timestamp { get; private set; }

        private void Validate(int quantity, decimal pricePerUnit, DateTime timestamp)
        {
            Guard.AgainstOutOfRange<InvalidClientTransactionException>(
                quantity,
                Zero,
                int.MaxValue,
                nameof(quantity));

            Guard.AgainstOutOfRange<InvalidClientTransactionException>(
                pricePerUnit,
                Zero,
                decimal.MaxValue,
                nameof(pricePerUnit));

            Guard.AgainstDefault<InvalidClientTransactionException>(
                timestamp,
                nameof(timestamp));
        }
    }
}


