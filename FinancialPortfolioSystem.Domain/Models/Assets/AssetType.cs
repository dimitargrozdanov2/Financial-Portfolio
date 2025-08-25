using FinancialPortfolioSystem.Domain.Common;

namespace FinancialPortfolioSystem.Domain.Models.Assets;

public class AssetType(int value, string name) : Enumeration(value, name)
{
    public static readonly AssetType Stock = new AssetType(1, nameof(Stock));
    public static readonly AssetType ETF = new AssetType(2, nameof(ETF));
    public static readonly AssetType Bond = new AssetType(3, nameof(Bond));
}
