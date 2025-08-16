using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Exceptions
{
    public class InvalidClientPortfolioException : BaseDomainException
    {
        public InvalidClientPortfolioException()
        {
        }

        public InvalidClientPortfolioException(string message) => this.Error = message;
    }
}
