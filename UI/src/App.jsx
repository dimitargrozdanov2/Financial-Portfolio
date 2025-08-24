import { useState } from "react";
import axios from "axios";
import LoginForm from "./components/LoginForm";
import Portfolio from "./components/Portfolio/Portfolio";          // user only
import Metrics from "./components/Metrics";              // user only
import AssetManagement from "./components/AssetManagement"; // admin only
import { ToastContainer, toast } from 'react-toastify';
import { jwtDecode } from "jwt-decode";
import { handleApiError } from "./utils/errorHandler";

function App() {
  const [token, setToken] = useState("");
  const [assets, setAssets] = useState([]);
  const [holdings, setHoldings] = useState([]);
  const [metrics, setMetrics] = useState(null);
  const [view, setView] = useState("client"); // "user" | "admin" | "app"
  const [role, setRole] = useState("");     // "user" | "admin"

  // --- API instance with auth header ---
  const api = axios.create({
    baseURL: "https://localhost:7081/api",
    headers: { Authorization: token ? `Bearer ${token}` : "" }
  });

  // --- Unified Login (user & admin) ---
  async function login(email, password) {
    try {
      const res = await axios.post("https://localhost:7081/api/identity/login", {
        email,
        password
      });

      const decoded = jwtDecode(res.data.token);
      console.log("Decoded JWT:", decoded);

      setToken(res.data.token);
      setRole(decoded.role.toLowerCase());  // normalize role
      setView("app");

      toast.success(`✅ ${decoded.role} login successful!`);
    } catch (err) {
      handleApiError(err, "Login failed");
    }
  }

  // --- Assets CRUD (admin only) ---
  async function loadAssets() {
    try {
    const res = await api.get("/assets");
    setAssets(res.data.items ?? res.data);
    } catch (err) {
    handleApiError(err, "Failed to load assets");
  }}

  async function addAsset(asset) {
    try {
    await api.post("/assets", asset);
    loadAssets();
    } catch (err) {
    handleApiError(err, "Failed to add an asset");
  }}

  async function updateAsset(id, asset) {
    try {
    await api.put(`/assets/${id}`, asset);
    loadAssets();
    } catch (err) {
      handleApiError(err, "Failed to update an asset");    
    }
  }

  async function deleteAsset(id) {
    try {
    await api.delete(`/assets/${id}`);
    loadAssets();
    } catch (err) {
      handleApiError(err, "Failed to delete an asset");    
    }
  }

  // --- User actions (buy/sell + metrics) ---
  async function loadHoldings() {
    try {
    const res = await api.get("/clientportfolio");
    setHoldings(res.data);
    } catch (err) {
      handleApiError(err, "Failed to load client holdings");    
  }}

  async function buyAsset(assetId, qty) {
    try {
    await api.post("/clientportfolio/buy", { assetId, quantity: parseInt(qty) });
    loadHoldings();
    } catch (err) {
      handleApiError(err, "Failed to buy an asset");   
  }}

  async function sellAsset(assetId, qty) {
    try {
    await api.post("/clientportfolio/sell", { assetId, quantity: parseInt(qty) });
    loadHoldings();
    } catch (err) {
      handleApiError(err, "Failed to sell an asset");   
  }}

  async function loadMetrics() {
    try {
    const res = await api.get("/clientportfolio/metrics");
    setMetrics(res.data);
    } catch (err) {
      handleApiError(err, "Failed to load metrics");   
  }}

  return (
    <div style={{ padding: "20px", fontFamily: "sans-serif" }}>
      <h1>Financial Portfolio</h1>

      <ToastContainer position="top-right" autoClose={3000} />

      {/* Login screens */}
      {view === "client" && <LoginForm onLogin={login} userType="client"/>}
      {view === "admin" && <LoginForm onLogin={login} userType="admin" />} {/* reuse same form */}

      {/* After login */}
      {view === "app" && token && (
        <>
          {role === "client" && (
            <>
<Portfolio
  holdings={holdings}
  onLoadHoldings={loadHoldings}
  onBuyAsset={buyAsset}
  onSellAsset={sellAsset}
  assets={assets}
  onLoadAssets={loadAssets}
/>
              <Metrics metrics={metrics} onLoadMetrics={loadMetrics} />
            </>
          )}

          {role === "admin" && (
            <AssetManagement
              assets={assets}
              onLoadAssets={loadAssets}
              onAddAsset={addAsset}
              onUpdateAsset={updateAsset}
              onDeleteAsset={deleteAsset}
            />
          )}
        </>
      )}

      {/* Switcher (only on login screens) */}
      {view !== "app" && (
        <div style={{ marginTop: "20px" }}>
          {view === "client" && (
            <button onClick={() => setView("admin")}>
              🔑 Switch to Admin Login
            </button>
          )}
          {view === "admin" && (
            <button onClick={() => setView("client")}>
              👤 Switch to Client Login
            </button>
          )}
        </div>
      )}
    </div>
  );
}

export default App;