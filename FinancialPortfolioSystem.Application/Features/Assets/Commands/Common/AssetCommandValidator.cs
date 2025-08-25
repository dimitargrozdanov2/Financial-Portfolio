using FluentValidation;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;

internal class AssetCommandValidator<TCommand> : AbstractValidator<AssetCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public AssetCommandValidator()
    {
        this.RuleFor(c => c.TickerSymbol)
            .MinimumLength(MinTickerSymbolLength)
            .MaximumLength(MaxTickerSymbolLength)
            .NotEmpty();

        this.RuleFor(c => c.Description)
            .MinimumLength(MinDescriptionLength)
            .MaximumLength(MaxDescriptionLength)
            .NotEmpty();

        this.RuleFor(c => c.MarketPrice)
            .GreaterThan(Zero)
            .NotEmpty();        
    }
}
