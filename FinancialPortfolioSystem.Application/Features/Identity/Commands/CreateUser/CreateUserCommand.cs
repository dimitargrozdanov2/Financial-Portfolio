using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser
{
    public class CreateUserCommand : UserInputModel, ICommand<Result>
    {
        public string Name { get; set; }
    }
}
