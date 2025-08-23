using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings
{
    public class ClientAssetOutputModel
    {
        public int Quantity { get; set; }

        public string AssetName { get; set; }

        public string AssetTickerSymbol { get; set; }

        public decimal MarketPrice { get; set; }

        public decimal AssetTotalValue { get; set; }
    }
}
