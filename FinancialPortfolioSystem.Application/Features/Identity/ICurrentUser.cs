namespace FinancialPortfolioSystem.Application.Features.Identity
{
    public interface ICurrentUser
    {
        string UserId { get; }

        List<string> Roles { get; }
    }
}
