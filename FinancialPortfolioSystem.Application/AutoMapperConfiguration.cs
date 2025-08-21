using FinancialPortfolioSystem.Application.Features.Assets.Queries.GetAll;
using FinancialPortfolioSystem.Domain.Models.Assets;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolioSystem.Application
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<Asset, AssetOutputModel>.NewConfig();
            TypeAdapterConfig<List<Asset>, List<AssetOutputModel>>.NewConfig();
        }
    }
}
