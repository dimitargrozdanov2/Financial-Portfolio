using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll
{
    public class AssetOutputModel
    {
        public AssetType AssetType { get; }
        public string TickerSymbol { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal MarketPrice { get; }
    }
}
