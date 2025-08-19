using FinancialPortfolioSystem.Domain.Common;
using FinancialPortfolioSystem.Domain.Factories;
using FinancialPortfolioSystem.Domain.Models.Assets;
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

    public static IServiceCollection RegisterFactories(
        this IServiceCollection services)
    {

        var factoryInterface = typeof(IFactory<>);
        var assembly = Assembly.GetAssembly(factoryInterface);

        var factoryTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == factoryInterface));

        foreach (var implType in factoryTypes)
        {
            var specificInterface = implType.GetInterfaces()
                .FirstOrDefault(i => i != factoryInterface &&
                                     i.GetInterfaces().Any(ii =>
                                         ii.IsGenericType && ii.GetGenericTypeDefinition() == factoryInterface));

            if (specificInterface != null)
            {
                services.AddTransient(specificInterface, implType);
            }
            else
            {
                var genericInterface = implType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == factoryInterface);

                services.AddTransient(genericInterface, implType);
            }
        }

        return services;
    }

    public static IServiceCollection RegisterTransientInterfaces(
        this IServiceCollection services) => services.AddTransient<IInitialData, AssetData>();

}