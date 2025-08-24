import { useEffect, useState } from "react";
import { ToastContainer, toast } from 'react-toastify';

function AssetManagement({ api, assets, onLoadAssets, onAddAsset, onUpdateAsset, onDeleteAsset }) {
  const [newName, setNewName] = useState("");
  const [newTicker, setNewTicker] = useState("");
  const [newDescription, setNewDescription] = useState("");
  const [newMarketPrice, setNewMarketPrice] = useState("");
  const [newAssetType, setNewAssetType] = useState("1"); // default Stock
  const [editId, setEditId] = useState(null);
  const [editName, setEditName] = useState("");
  const [editTicker, setEditTicker] = useState("");
  const [editDescription, setEditDescription] = useState("");
  const [editMarketPrice, setEditMarketPrice] = useState("");
  // Load assets when component mounts
  useEffect(() => {
    onLoadAssets();
  }, []);

  const handleAdd = () => {
    if (!newName || !newTicker || !newDescription || !newMarketPrice || !newAssetType) {
      toast.error("Please fill in all fields");
      return;
    }

    onAddAsset({
      name: newName,
      tickerSymbol: newTicker,
      description: newDescription,
      marketPrice: parseFloat(newMarketPrice),
      assetType:  parseInt(newAssetType)
    });

    setNewName("");
    setNewTicker("");
    setNewDescription("");
    setNewMarketPrice("");
    setNewAssetType("1");
  };

  const handleUpdate = () => {
    if (!editTicker || !editName || !editDescription || !editMarketPrice){
    console.log("няма еррор!")
    console.log(editTicker)
    console.log(editName)
    console.log(editDescription)
    console.log(editMarketPrice)
      toast.error("Please fill in all fields");
      return;
    }

    onUpdateAsset(editId, {
      name: editName,
      tickerSymbol: editTicker,
      description: editDescription,
      marketPrice: parseFloat(editMarketPrice),
    });

    setEditId(null);
    setEditName("");
    setEditTicker("");
    setEditDescription("");
    setEditMarketPrice("");
  };

  return (
    <div style={{ marginTop: "20px" }}>
      <h2>📊 Asset Management (Admin Only)</h2>

      {/* Add new asset */}
      <div style={{ marginBottom: "20px" }}>
        <h3>Add Asset</h3>
        <input
          placeholder="Name"
          value={newName}
          onChange={(e) => setNewName(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          placeholder="Ticker Symbol"
          value={newTicker}
          onChange={(e) => setNewTicker(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          placeholder="Description"
          value={newDescription}
          onChange={(e) => setNewDescription(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          type="number"
          placeholder="Market Price"
          value={newMarketPrice}
          onChange={(e) => setNewMarketPrice(e.target.value)}
          style={{ marginRight: "10px" }}
        />

        <select
          value={newAssetType}
          onChange={(e) => setNewAssetType(e.target.value)}
          style={{ marginRight: "10px" }}
        >
          <option value="1">Stock</option>
          <option value="2">ETF</option>
          <option value="3">Bond</option>
        </select>

        <button onClick={handleAdd}>➕ Add</button>
      </div>

      {/* Edit existing asset */}
      {editId && (
        <div style={{ marginBottom: "20px" }}>
          <h3>Edit Asset</h3>
        <input
          placeholder="Name"
          value={editName}
          onChange={(e) => setEditName(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          placeholder="Ticker Symbol"
          value={editTicker}
          onChange={(e) => setEditTicker(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          placeholder="Description"
          value={editDescription}
          onChange={(e) => setEditDescription(e.target.value)}
          style={{ marginRight: "10px" }}
        />
        <input
          type="number"
          placeholder="Market Price"
          value={editMarketPrice}
          onChange={(e) => setEditMarketPrice(e.target.value)}
          style={{ marginRight: "10px" }}
        />
          <button onClick={handleUpdate}>💾 Save</button>
          <button onClick={() => setEditId(null)} style={{ marginLeft: "10px" }}>
            ❌ Cancel
          </button>
        </div>
      )}

      {/* Asset list */}
      <h3>Existing Assets</h3>
      {assets.length === 0 ? (
        <p>No assets available</p>
      ) : (
        <ul>
          {assets.map((a) => (
            <li key={a.id} style={{ marginBottom: "10px" }}>
              <strong>{a.name}</strong> ({a.tickerSymbol}) — {a.assetType?.name}
              <br />
              💵 Market Price: {a.marketPrice}
              <br />
              📝 {a.description}
              <div style={{ marginTop: "5px" }}>
                <button
                  style={{ marginRight: "10px" }}
                  onClick={() => {
                    setEditId(a.id);
                    setEditName(a.name);
                    setEditTicker(a.tickerSymbol)
                    setEditDescription(a.description)
                    setEditMarketPrice(a.marketPrice)
                  }}
                >
                  ✏️ Edit
                </button>
                <button
                  style={{ color: "red" }}
                  onClick={() => onDeleteAsset(a.id)}
                >
                  🗑️ Delete
                </button>
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default AssetManagement;