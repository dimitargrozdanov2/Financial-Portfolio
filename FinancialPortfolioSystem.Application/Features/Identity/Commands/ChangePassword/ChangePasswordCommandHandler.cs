using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, Result>
{
    private readonly ICurrentUser _currentUser;
    private readonly IIdentity _identity;

    public ChangePasswordCommandHandler(
        ICurrentUser currentUser,
        IIdentity identity)
    {
        _currentUser = currentUser;
        _identity = identity;
    }

    public async Task<Result> HandleAsync(ChangePasswordCommand request, CancellationToken cancellationToken = default)
        => await _identity.ChangePasswordAsync(new ChangePasswordInputModel(
            _currentUser.UserId,
            request.CurrentPassword,
            request.NewPassword));
}
