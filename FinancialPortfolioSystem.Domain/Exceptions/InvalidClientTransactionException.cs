using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Exceptions
{
    public class InvalidClientTransactionException : BaseDomainException
    {
        public InvalidClientTransactionException()
        {
        }

        public InvalidClientTransactionException(string message) => this.Error = message;
    }
}
