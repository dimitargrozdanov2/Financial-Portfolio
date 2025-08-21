using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Common
{
    public class AssetCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int AssetType { get; set; }

        public string TickerSymbol { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal MarketPrice { get; set; }
    }
}
