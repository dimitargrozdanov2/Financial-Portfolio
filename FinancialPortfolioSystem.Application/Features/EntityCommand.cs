using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features
{
    public class EntityCommand<TId>
    {
        internal TId Id { get; set; } = default;
    }
}
