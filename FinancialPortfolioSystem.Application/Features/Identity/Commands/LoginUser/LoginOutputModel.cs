namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

public class LoginOutputModel(string token)
{
    public string Token { get; } = token;
}
