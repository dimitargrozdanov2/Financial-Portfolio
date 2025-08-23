using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Models.Assets;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.BuyAsset
{
    public class BuyClientAssetCommandValidator : AbstractValidator<BuyClientAssetCommand>
    {
        public BuyClientAssetCommandValidator() => this.Include(new ClientAssetCommandValidator<BuyClientAssetCommand>());
    }
}
