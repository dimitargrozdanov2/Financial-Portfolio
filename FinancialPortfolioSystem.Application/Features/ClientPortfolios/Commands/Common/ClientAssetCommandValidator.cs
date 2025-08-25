using FluentValidation;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;

public class ClientAssetCommandValidator<TCommand> : AbstractValidator<ClientAssetCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public ClientAssetCommandValidator()
    {
        RuleFor(c => c.Quantity)
            .GreaterThan(Zero)
            .NotEmpty();
    }
}
