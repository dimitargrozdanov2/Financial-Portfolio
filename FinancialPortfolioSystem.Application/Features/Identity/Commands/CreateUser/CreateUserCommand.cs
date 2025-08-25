using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser;

public class CreateUserCommand : UserInputModel, ICommand<Result>
{
    public string Name { get; set; }
}
