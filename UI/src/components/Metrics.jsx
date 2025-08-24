export default function Metrics({ metrics, onLoadMetrics }) {
  return (
    <section>
      <h2>Metrics</h2>
      <button onClick={onLoadMetrics}>Get Metrics</button>

      {metrics && (
        <table style={{ marginTop: "1rem", borderCollapse: "collapse", width: "100%" }}>
          <thead>
            <tr>
              {Object.keys(metrics).map((key) => (
                <th
                  key={key}
                  style={{
                    border: "1px solid #ccc",
                    padding: "8px",
                    textAlign: "left",
                  }}
                >
                  {key}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            <tr>
              {Object.entries(metrics).map(([key, value]) => (
                <td
                  key={key}
                  style={{
                    border: "1px solid #ccc",
                    padding: "8px",
                    color:
                      key.toLowerCase() === "roi"
                        ? value < 0
                          ? "red"
                          : "green"
                        : "inherit",
                  }}
                >
                  {typeof value === "number"
                    ? value.toFixed(2)
                    : String(value)}
                </td>
              ))}
            </tr>
          </tbody>
        </table>
      )}
    </section>
  );
}