using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using FinancialPortfolioSystem.Domain.Models.Assets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Asset;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Common
{
    internal class AssetCommandValidator<TCommand> : AbstractValidator<AssetCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public AssetCommandValidator()
        {
            this.RuleFor(c => c.AssetType)
                .Must(Enumeration.HasValue<AssetType>)
                .WithMessage("'Asset type' is not valid.");

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
}
