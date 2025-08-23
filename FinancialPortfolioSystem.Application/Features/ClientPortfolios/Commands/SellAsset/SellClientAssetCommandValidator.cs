using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.SellAsset;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolios.Commands.SellAsset
{
    internal class SellClientAssetCommandValidator : AbstractValidator<SellClientAssetCommand>
    {
        public SellClientAssetCommandValidator() => this.Include(new ClientAssetCommandValidator<SellClientAssetCommand>());
    }
}
