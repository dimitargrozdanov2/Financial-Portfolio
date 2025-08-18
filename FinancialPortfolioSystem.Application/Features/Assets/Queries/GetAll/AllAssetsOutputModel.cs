using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll
{
    public class AllAssetsOutputModel
    {
        public List<AssetOutputModel> Items { get; set; }

        public int Count { get; set; }
    }
}
