using FinancialPortfolioSystem.Application.Features.Assets.Commands.Common;
using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinancialPortfolioSystem.Domain.Models.ModelConstants.Common;

namespace FinancialPortfolioSystem.Application.Features.ClientPortfolio.Commands.Common
{
    public class ClientAssetCommandValidator<TCommand> : AbstractValidator<ClientAssetCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ClientAssetCommandValidator()
        {
            this.RuleFor(c => c.Quantity)
                .GreaterThan(Zero)
                .NotEmpty();
        }
    }
}
