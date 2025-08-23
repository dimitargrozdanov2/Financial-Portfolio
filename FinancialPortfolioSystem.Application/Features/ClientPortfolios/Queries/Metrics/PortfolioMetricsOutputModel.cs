using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Metrics
{
    public class PortfolioMetricsOutputModel
    {
        public decimal TotalInvestedAmount { get; set; }

        public decimal CurrentMarketValue { get; set; }

        public string ROI { get; set; }
    }
}
