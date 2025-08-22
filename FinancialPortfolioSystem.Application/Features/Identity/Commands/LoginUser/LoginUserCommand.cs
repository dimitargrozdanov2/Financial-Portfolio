using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginUserCommand : UserInputModel, ICommand<Result<LoginOutputModel>>
    {
    }
}
