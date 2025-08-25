using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, Result<LoginOutputModel>>
{
    private readonly IIdentity identity;

    public LoginUserCommandHandler(
        IIdentity identity)
    {
        this.identity = identity;
    }

    public async Task<Result<LoginOutputModel>> HandleAsync(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await this.identity.Login(request);

        if (!result.Succeeded)
        {
            return result.Errors;
        }

        var user = result.Data;

        return new LoginOutputModel(user.Token);
    }
}
