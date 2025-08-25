namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

public class LoginSuccessModel(string userId, string token)
{
    public string UserId { get; } = userId;

    public string Token { get; } = token;
}
