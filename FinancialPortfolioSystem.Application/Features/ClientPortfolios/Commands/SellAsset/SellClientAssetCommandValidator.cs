using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Commands.SellAsset;

internal class SellClientAssetCommandValidator : AbstractValidator<SellClientAssetCommand>
{
    public SellClientAssetCommandValidator() => this.Include(new ClientAssetCommandValidator<SellClientAssetCommand>());
}
