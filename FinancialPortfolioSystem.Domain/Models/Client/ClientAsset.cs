using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client
{
    public class ClientAsset : ValueObject
    {
        internal ClientAsset(Guid assetId, int quantity, decimal totalAmountPaid)
        {
            Validate(quantity, totalAmountPaid);

            this.AssetId = assetId;
            this.Quantity = quantity;
            this.TotalAmountPaid = totalAmountPaid;
        }

        public Guid AssetId { get; }
        public int Quantity { get; private set; }
        public decimal TotalAmountPaid { get; private set; }

        private void Validate(int quantity, decimal totalAmountPaid)
        {
            Guard.AgainstOutOfRange<InvalidClientAssetException>(
                quantity,
                Zero,
                int.MaxValue,
                nameof(this.Quantity));

            Guard.AgainstOutOfRange<InvalidClientAssetException>(
                totalAmountPaid,
                Zero,
                decimal.MaxValue,
                nameof(this.TotalAmountPaid));
        }

        internal void ApplyTransaction(ClientTransaction transaction)
        {
            if (transaction.Type.Equals(ClientTransactionType.Buy))
            {
                Quantity += transaction.Quantity; //test to see if transaction parameters are populated
                TotalAmountPaid += transaction.Quantity * transaction.PricePerUnit;
            }
            else if (transaction.Type.Equals(ClientTransactionType.Sell))
            {
                Quantity -= transaction.Quantity;
                TotalAmountPaid -= transaction.Quantity * (TotalAmountPaid / Quantity);
            }
        }
    }
}
