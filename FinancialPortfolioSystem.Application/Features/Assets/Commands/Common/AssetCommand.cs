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
        public int AssetType { get; }

        public string TickerSymbol { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal MarketPrice { get; }
    }
}
