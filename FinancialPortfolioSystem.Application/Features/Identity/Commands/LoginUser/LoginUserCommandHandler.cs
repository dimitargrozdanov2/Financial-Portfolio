using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.LoginUser;

public class LoginUserCommandHandler(
    IIdentity identity) : ICommandHandler<LoginUserCommand, Result<LoginOutputModel>>
{
    private readonly IIdentity _identity = identity;

    public async Task<Result<LoginOutputModel>> HandleAsync(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _identity.LoginAsync(request);

        if (!result.Succeeded)
        {
            return result.Errors;
        }

        var user = result.Data;

        return new LoginOutputModel(user.Token);
    }
}
