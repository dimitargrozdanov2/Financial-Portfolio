using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Update;

internal class UpdateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
{
    public UpdateAssetCommandValidator() => Include(new AssetCommandValidator<CreateAssetCommand>());
}
