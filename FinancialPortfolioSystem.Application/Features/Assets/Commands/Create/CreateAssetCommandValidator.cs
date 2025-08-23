using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using FluentValidation;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create
{
    public class CreateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
    {
        public CreateAssetCommandValidator()
        {
            this.RuleFor(c => c.AssetType)
                .Must(Enumeration.HasValue<AssetType>)
                .WithMessage("'Asset type' is not valid.");

            this.Include(new AssetCommandValidator<CreateAssetCommand>());
        }
    }
}
