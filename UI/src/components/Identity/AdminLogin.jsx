import { useState } from "react";

export default function AdminLogin({ onAdminLogin }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  return (
    <section>
      <h2>Admin Login</h2>
      <input
        placeholder="Admin Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button onClick={() => onAdminLogin(email, password)}>Login as Admin</button>

      <div style={{ marginTop: "10px" }}>
        <a href="/">⬅ Back to Client Login</a>
      </div>
    </section>
  );
}