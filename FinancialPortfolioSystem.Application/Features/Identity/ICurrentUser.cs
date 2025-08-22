using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Identity
{
    public interface ICurrentUser
    {
        string UserId { get; }
    }
}
