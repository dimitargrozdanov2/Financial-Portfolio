export default function CurrentPortfolio({ holdings, onLoadHoldings, onBuyAsset, onSellAsset }) {
  const items = holdings?.items ?? [];

  return (
    <section>
      <h2>Current Portfolio</h2>
      <button onClick={onLoadHoldings}>Load Holdings</button>

      <table border="1" cellPadding="8" style={{ marginTop: "10px", borderCollapse: "collapse" }}>
        <thead>
          <tr>
            <th>Quantity</th>
            <th>Asset Name</th>
            <th>Asset Ticker</th>
            <th>Market Price</th>
            <th>Asset Total Value</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {items.map((holding) => (
            <tr key={holding.id}>
              <td>{holding.quantity}</td>
              <td>{holding.assetName}</td>
              <td>{holding.assetTickerSymbol}</td>
              <td>{holding.marketPrice}</td>
              <td>{holding.assetTotalValue}</td>
              <td>
                <button onClick={() => onBuyAsset(holding.assetId, 1)}>Buy 1</button>{" "}
                <button onClick={() => onSellAsset(holding.assetId, 1)}>Sell 1</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {holdings && (
        <p style={{ marginTop: "10px" }}>
          <strong>Total Portfolio Value:</strong> {holdings.totalValue}
        </p>
      )}
    </section>
  );
}