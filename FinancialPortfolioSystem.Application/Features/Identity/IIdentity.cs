using FinancialPortfolioSystem.Application.Common;
using FinancialPortfolioSystem.Application.Features.Identity.Commands;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

namespace FinancialPortfolioSystem.Application.Features.Identity;

public interface IIdentity
{
    Task<Result> RegisterAsync(UserInputModel userInput);

    Task<Result<LoginOutputModel>> LoginAsync(UserInputModel userInput);

    Task<Result> ChangePasswordAsync(ChangePasswordInputModel changePasswordInput);
}
