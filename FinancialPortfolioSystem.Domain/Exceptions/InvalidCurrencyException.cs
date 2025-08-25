namespace FinancialPortfolioSystem.Domain.Exceptions;

internal class InvalidCurrencyException : BaseDomainException
{
    public InvalidCurrencyException()
    {
    }

    public InvalidCurrencyException(string message) => Error = message;
}
