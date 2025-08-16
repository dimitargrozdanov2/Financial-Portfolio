using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Exceptions
{
    public class InvalidAssetException : BaseDomainException
    {
        public InvalidAssetException() 
        { 
        }

        public InvalidAssetException(string message) => this.Error = message;
    }
}
