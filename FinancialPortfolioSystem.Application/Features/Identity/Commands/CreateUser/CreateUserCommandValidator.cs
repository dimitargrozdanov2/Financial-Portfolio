using FluentValidation;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        this.RuleFor(u => u.Email)
            .MinimumLength(MinEmailLength)
            .MaximumLength(MaxEmailLength)
            .EmailAddress()
            .NotEmpty();

        this.RuleFor(u => u.Password)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(u => u.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}
