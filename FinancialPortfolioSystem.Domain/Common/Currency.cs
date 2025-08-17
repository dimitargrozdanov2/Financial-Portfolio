using FinancialPortfolioSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Domain.Common
{
    public class Currency : ValueObject
    {
        internal Currency(string name, decimal value)
        {
            this.Validate(name, value);

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public Currency IncreaseBy(decimal amount) => new Currency(this.Name, this.Value + amount);
        public Currency DecreaseBy(decimal amount) => new Currency(this.Name, this.Value - amount);

        private void Validate(string name, decimal value)
        {
            Guard.ForStringLength<InvalidCurrencyException>(
                name,
                MinNameLength,
                MaxCurrencyLength,
                nameof(this.Name));

            Guard.AgainstOutOfRange<InvalidCurrencyException>(
                value,
                Zero,
                decimal.MaxValue,
                nameof(this.Value));
        }
    }
}
