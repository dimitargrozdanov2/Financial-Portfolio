import { useEffect } from "react";
import AvailableAssets from "./AvailableAssets";
import CurrentPortfolio from "./CurrentPortfolio";
import TradeControls from "./TradeControls";

export default function Portfolio({ holdings, onLoadHoldings, onBuyAsset, onSellAsset, assets, onLoadAssets }) {
useEffect(() => {
  onLoadAssets();
}, []);

  return (
    <section>
      <AvailableAssets assets={assets} onBuyAsset={onBuyAsset} />
      <CurrentPortfolio
        holdings={holdings}
        onLoadHoldings={onLoadHoldings}
        onBuyAsset={onBuyAsset}
        onSellAsset={onSellAsset}
      />
      <TradeControls holdings={holdings} onBuyAsset={onBuyAsset} onSellAsset={onSellAsset} />
    </section>
  );
}