using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

internal class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        this.RuleFor(u => u.Email)
            .NotEmpty();

        this.RuleFor(u => u.Password)
            .NotEmpty();
    }
}
