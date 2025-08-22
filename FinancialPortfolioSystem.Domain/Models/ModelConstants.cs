namespace FinancialPortfolioSystem.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int Zero = 0;
            public const int MaxCurrencyLength = 25;
        }

        public class Asset
        {
            public const int MinTickerSymbolLength = 1;
            public const int MaxTickerSymbolLength = 10;
            public const int MinDescriptionLength = 10;
            public const int MaxDescriptionLength = 1000;
        }

        public class Transaction
        {
            public const int MinTransactionQuantity = 1;
        }
    }
}
