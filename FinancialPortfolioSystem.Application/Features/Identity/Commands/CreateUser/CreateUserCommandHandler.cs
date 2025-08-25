using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.CreateUser;

internal class CreateUserCommandHandler(IIdentity identity) : ICommandHandler<CreateUserCommand, Result>
{
    private readonly IIdentity _identity = identity;

    public async Task<Result> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        var result = await _identity.RegisterAsync(request);

        return result;
    }
}
