using FinancialPortfolioSystem.Domain.Common;

namespace FinancialPortfolioSystem.Domain.Models.Assets
{
    public class AssetData : IInitialData
    {
        public Type EntityType => typeof(Asset);

        public IEnumerable<object> SeedData()
            => new List<Asset>
            {
                new Asset(AssetType.Stock, "AAPL", "Apple Inc", "Apple Inc. designs, manufactures, and markets smartphones, personal computers, tablets, wearables, and accessories worldwide. The company offers iPhone, a line of smartphones; Mac, a line of personal computers; iPad, a line of multi-purpose tablets; and wearables, home, and accessories comprising AirPods, Apple TV, Apple Watch, Beats products, and HomePod", 231.59M),
                new Asset(AssetType.Stock, "AMZN", "Amazon.com Inc", "Amazon.com, Inc. engages in the retail sale of consumer products, advertising, and subscriptions service through online and physical stores in North America and internationally.", 231.03M),
                new Asset(AssetType.Stock, "OMV", "OMV AG", "OMV Aktiengesellschaft operates as an oil, gas, and chemicals company in Austria, Belgium, Germany, New Zealand, Norway, Romania, the United Arab Emirates, the rest of Central and Eastern Europe, the rest of Europe, and internationally.",47.70M)
            };
    }
}
