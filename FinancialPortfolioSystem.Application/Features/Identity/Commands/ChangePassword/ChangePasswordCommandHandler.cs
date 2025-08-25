using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;

public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, Result>
{
    private readonly ICurrentUser currentUser;
    private readonly IIdentity identity;

    public ChangePasswordCommandHandler(
        ICurrentUser currentUser,
        IIdentity identity)
    {
        this.currentUser = currentUser;
        this.identity = identity;
    }

    public async Task<Result> HandleAsync(ChangePasswordCommand request, CancellationToken cancellationToken = default)
        => await this.identity.ChangePassword(new ChangePasswordInputModel(
            this.currentUser.UserId,
            request.CurrentPassword,
            request.NewPassword));
}
