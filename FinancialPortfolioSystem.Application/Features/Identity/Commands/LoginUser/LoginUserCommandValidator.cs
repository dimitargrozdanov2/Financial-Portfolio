using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

internal class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty();

        RuleFor(u => u.Password)
            .NotEmpty();
    }
}
