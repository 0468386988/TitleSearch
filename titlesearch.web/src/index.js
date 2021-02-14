import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { EngineProvider } from "./context/engine_context";
import { SearchProvider } from "./context/search_context";

ReactDOM.render(
  <React.StrictMode>
    <EngineProvider>
      <SearchProvider>
        <App />
      </SearchProvider>
    </EngineProvider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
