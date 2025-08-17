using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Domain.Exceptions
{
    internal class InvalidCurrencyException : BaseDomainException
    {
        public InvalidCurrencyException()
        {
        }

        public InvalidCurrencyException(string message) => this.Error = message;
    }
}
