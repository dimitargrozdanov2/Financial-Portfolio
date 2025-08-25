using FluentValidation;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;

internal class AssetCommandValidator<TCommand> : AbstractValidator<AssetCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public AssetCommandValidator()
    {
        RuleFor(c => c.TickerSymbol)
            .MinimumLength(MinTickerSymbolLength)
            .MaximumLength(MaxTickerSymbolLength)
            .NotEmpty();

        RuleFor(c => c.Description)
            .MinimumLength(MinDescriptionLength)
            .MaximumLength(MaxDescriptionLength)
            .NotEmpty();

        RuleFor(c => c.MarketPrice)
            .GreaterThan(Zero)
            .NotEmpty();        
    }
}
