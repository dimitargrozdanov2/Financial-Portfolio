using FinancialPortfolioSystem.Domain.Models.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common
{
    public class ClientAssetCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public int AssetId { get; set; }
        public int Quantity { get; set; }
    }
}
