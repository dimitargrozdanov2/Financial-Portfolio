using FinancialPortfolioSystem.Application.Features.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinancialPortfolioSystem.Web.Services
{
    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            this.Roles = user.FindAll(ClaimTypes.Role).Select(x => x.Value).ToList();
        }

        public string UserId { get; }

        public List<string> Roles { get; }
    }
}
