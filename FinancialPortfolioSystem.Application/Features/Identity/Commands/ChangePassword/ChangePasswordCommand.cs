using FinancialPortfolioSystem.Application.Common;
using LiteBus.Commands.Abstractions;

namespace FinancialPortfolioSystem.Application.Features.Identity.Commands.ChangePassword;

public class ChangePasswordCommand : ICommand<Result>
{
    public string CurrentPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;
}
