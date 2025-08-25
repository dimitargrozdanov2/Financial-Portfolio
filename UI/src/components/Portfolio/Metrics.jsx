export default function Metrics({ metrics, onLoadMetrics }) {
  // helper to convert to PascalCase
  const toPascalCase = (str) =>
    str
      .replace(/(^\w|_\w)/g, (match) => match.replace("_", "").toUpperCase());

  return (
    <section>
      <h2>Metrics</h2>
      <button onClick={onLoadMetrics}>Get Metrics</button>

      {metrics && (
        <table
          style={{
            marginTop: "1rem",
            borderCollapse: "collapse",
            width: "100%",
          }}
        >
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
                  {toPascalCase(key)}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            <tr>
              {Object.entries(metrics).map(([key, value]) => {
                const isROI = key.toLowerCase() === "roi";

                let numericValue = Number(value);
                let displayValue;

                if (isROI && !isNaN(numericValue)) {
                  const arrow = numericValue >= 0 ? "↑" : "↓";
                  displayValue = `${numericValue.toFixed(2)}% ${arrow}`;
                } else if (!isNaN(numericValue)) {
                  displayValue = numericValue.toFixed(2);
                } else {
                  displayValue = String(value);
                }

                return (
                  <td
                    key={key}
                    style={{
                      border: "1px solid #ccc",
                      padding: "8px",
                      fontWeight: isROI ? "bold" : "normal",
                      color: isROI
                        ? numericValue < 0
                          ? "red"
                          : "green"
                        : "inherit",
                    }}
                  >
                    {displayValue}
                  </td>
                );
              })}
            </tr>
          </tbody>
        </table>
      )}
    </section>
  );
}