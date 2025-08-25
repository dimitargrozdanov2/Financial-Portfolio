using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using FluentValidation;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;

public class BuyClientAssetCommandValidator : AbstractValidator<BuyClientAssetCommand>
{
    public BuyClientAssetCommandValidator() => Include(new ClientAssetCommandValidator<BuyClientAssetCommand>());
}
