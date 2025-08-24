export default function AvailableAssets({ assets, onBuyAsset }) {
  return (
    <section>
      <h2>Assets available on the Market</h2>
      <table border="1" cellPadding="6">
        <thead>
          <tr>
            <th>ID</th>
            <th>Type</th>
            <th>Ticker</th>
            <th>Name</th>
            <th>Description</th>
            <th>Market Price</th>
            <th>Buy</th>
          </tr>
        </thead>
        <tbody>
          {assets.length > 0 ? (
            assets.map((a) => (
              <tr key={a.id}>
                <td>{a.id}</td>
                <td>{a.assetType?.name}</td>
                <td>{a.tickerSymbol}</td>
                <td>{a.name}</td>
                <td>{a.description}</td>
                <td>${a.marketPrice.toFixed(2)}</td>
                <td>
                  <button onClick={() => onBuyAsset(a.id, 1)}>Buy 1</button>
                </td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="7">No assets found</td>
            </tr>
          )}
        </tbody>
      </table>
    </section>
  );
}