using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

public class LoginUserCommand : UserInputModel, ICommand<Result<LoginOutputModel>>
{
}
