import { useState } from "react";

export default function TradeControls({ holdings, onBuyAsset, onSellAsset }) {
  const [selectedHolding, setSelectedHolding] = useState("");
  const [quantity, setQuantity] = useState("");

  const items = holdings?.items ?? [];

  return (
    <section>
      <h3>Buy/Sell Custom Quantity</h3>
      <select value={selectedHolding} onChange={(e) => setSelectedHolding(e.target.value)}>
        <option value="">Select Holding</option>
        {items.map((holding) => (
          <option key={holding.assetId} value={holding.assetId}>
            {holding.assetName} ({holding.assetTickerSymbol})
          </option>
        ))}
      </select>

      <input
        type="number"
        placeholder="Quantity"
        value={quantity}
        onChange={(e) => setQuantity(e.target.value)}
        style={{ marginLeft: "8px" }}
      />
      <button
        onClick={() => {
          if (selectedHolding && quantity) {
            onBuyAsset(selectedHolding, Number(quantity));
            setQuantity("");
          }
        }}
        style={{ marginLeft: "4px" }}
      >
        Buy
      </button>
      <button
        onClick={() => {
          if (selectedHolding && quantity) {
            onSellAsset(selectedHolding, Number(quantity));
            setQuantity("");
          }
        }}
        style={{ marginLeft: "4px" }}
      >
        Sell
      </button>
    </section>
  );
}
