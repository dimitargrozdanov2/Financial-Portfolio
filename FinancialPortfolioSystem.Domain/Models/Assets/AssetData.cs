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
                new Asset(AssetType.Stock, "GOOGL", "Alphabet Inc", "Alphabet Inc. offers various products and platforms in the United States, Europe, the Middle East, Africa, the Asia-Pacific, Canada, and Latin America. It operates through Google Services, Google Cloud, and Other Bets segments. The Google Services segment provides products and services, including ads, Android, Chrome, devices, Gmail, Google Drive, Google Maps, Google Photos, Google Play, Search, and YouTube.", 199.75M),
            };
    }
}
