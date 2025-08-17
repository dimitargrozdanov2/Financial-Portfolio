using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 50;
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
    }
}
