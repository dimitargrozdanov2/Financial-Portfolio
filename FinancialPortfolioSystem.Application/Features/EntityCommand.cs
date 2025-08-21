using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features
{
    public class EntityCommand<TId>
    {
        public TId Id { get; set; } = default;
    }
}
