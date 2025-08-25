import { useState } from "react";

export default function LoginForm({ onLogin, userType }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  // Determine title based on userType prop
  const title = userType === "admin" ? "Admin Login" : "Client Login";

  return (
    <section>
      <h2>{title}</h2>
      <input
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />
      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button onClick={() => onLogin(email, password)}>Login</button>
    </section>
  );
}