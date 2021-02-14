import React, { useState, useContext, useEffect } from "react";

import { ENGINE_LOADING, ENGINE_SUCCESS, API_NOT_FOUND } from "../enums";

const url =
  "https://titlesearchapi20210214101148.azurewebsites.net/api/supportedengines";
const EngineContext = React.createContext();

const EngineProvider = ({ children }) => {
  const [engineStatus, setEngineStatus] = useState(ENGINE_LOADING);
  const [engines, setEngines] = useState([]);

  const fetchEngines = async () => {
    setEngineStatus(ENGINE_LOADING);
    try {
      const response = await fetch(`${url}`);
      const data = await response.json();

      if (data) {
        setEngines(data);
      } else {
        setEngines([]);
      }
      setEngineStatus(ENGINE_SUCCESS);
    } catch (error) {
      setEngineStatus(error.message);
    }
  };
  useEffect(() => {
    fetchEngines();
  }, []);
  return (
    <EngineContext.Provider value={{ engineStatus, engines }}>
      {children}
    </EngineContext.Provider>
  );
};
// make sure use
export const useEngineContext = () => {
  return useContext(EngineContext);
};

export { EngineContext, EngineProvider };
