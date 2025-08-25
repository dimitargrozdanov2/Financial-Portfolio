using FinancialPortfolioSystem.Application.Features.Identity;
using FinancialPortfolioSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolioSystem.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
    {
        services
            .AddHttpContextAccessor()
            .AddScoped<ICurrentUser, CurrentUserService>()
            .AddControllers()
            .AddNewtonsoftJson();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}
