namespace FinancialPortfolioSystem.Application;

public class ApplicationSettings(string secret = default!)
{
    public string Secret { get; private set; } = secret;
}