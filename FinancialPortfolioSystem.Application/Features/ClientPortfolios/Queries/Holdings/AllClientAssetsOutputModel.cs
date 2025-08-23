using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Queries.Holdings
{
    public class AllClientAssetsOutputModel
    {
        public List<ClientAssetOutputModel> Items { get; set; }

        public decimal TotalValue { get; set; }
    }
}
