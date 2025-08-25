namespace FinancialPortfolioSystem.Domain.Exceptions;

public class InvalidClientPortfolioException : BaseDomainException
{
    public InvalidClientPortfolioException()
    {
    }

    public InvalidClientPortfolioException(string message) => Error = message;
}
