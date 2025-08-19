using FinancialPortfolioSystem.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FinancialPortfolioSystem.Web.Extensions
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
