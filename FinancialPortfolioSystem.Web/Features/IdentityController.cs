using FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser;
using FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;
using FinancialPortfolioSystem.Web.Common;
using FinancialPortfolioSystem.Web.Façade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolioSystem.Web.Features;

public class IdentityController : ApiController
{

    public IdentityController(IAppMediator mediator) : base(mediator) { }

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(
        CreateUserCommand command)
        => await this.SendAsync(command);

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<LoginOutputModel>> Login(
        LoginUserCommand command)
        => await this.SendAsync(command);


    [HttpPut]
    [Authorize]
    [Route(nameof(ChangePassword))]
    public async Task<ActionResult> ChangePassword(
        ChangePasswordCommand command)
        => await this.SendAsync(command);
}
