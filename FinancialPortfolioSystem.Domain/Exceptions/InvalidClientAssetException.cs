using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Exceptions
{
    public class InvalidClientAssetException : BaseDomainException
    {
        public InvalidClientAssetException()
        {
        }

        public InvalidClientAssetException(string message) => this.Error = message;
    }
}
