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
