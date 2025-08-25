using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;

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
