using LiteBus;
using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(cmd =>
            {
                cmd.RegisterFromAssembly(Assembly.GetExecutingAssembly());
            });

            liteBus.AddQueryModule(q =>
            {
                q.RegisterFromAssembly(Assembly.GetExecutingAssembly());
            });
        });

        services.AddMapster();

        return services;
    }
}