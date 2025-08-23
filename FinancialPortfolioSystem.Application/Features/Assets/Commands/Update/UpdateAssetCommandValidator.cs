using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Application.Features.Assets.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Assets.Commands.Update
{
    internal class UpdateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
    {
        public UpdateAssetCommandValidator() => this.Include(new AssetCommandValidator<CreateAssetCommand>());
    }
}
