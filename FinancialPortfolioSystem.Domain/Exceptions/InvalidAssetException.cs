namespace FinancialPortfolioSystem.Domain.Exceptions;

public class InvalidAssetException : BaseDomainException
{
    public InvalidAssetException() 
    { 
    }

    public InvalidAssetException(string message) => this.Error = message;
}
