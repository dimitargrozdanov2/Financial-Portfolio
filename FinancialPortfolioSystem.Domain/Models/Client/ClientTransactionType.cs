using FinancialPortfolioSystem.Domain.Common;

namespace FinancialPortfolioSystem.Domain.Models.Client
{
    public class ClientTransactionType : Enumeration
    {
        public static readonly ClientTransactionType Buy = new ClientTransactionType(1, nameof(Buy));
        public static readonly ClientTransactionType Sell = new ClientTransactionType(2, nameof(Sell));

        public ClientTransactionType(int value, string name)
            : base(value, name)
        {
        }
    }
}
