using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Common
{
    public interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> SeedData();
    }
}
