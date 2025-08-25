namespace FinancialPortfolioSystem.Domain.Exceptions;

public class InvalidClientTransactionException : BaseDomainException
{
    public InvalidClientTransactionException()
    {
    }

    public InvalidClientTransactionException(string message) => Error = message;
}
