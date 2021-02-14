import React, { useState, useContext, useEffect } from "react";
import {
  SEARCH_NOT_START,
  API_NOT_FOUND,
  SEARCH_ENGINE_ERROR,
  SEARCH_SUCCESS,
  SEARCH_LOADING,
  SEARCH_NO_RECORD,
} from "../enums";

const apiUrl =
  "https://titlesearchapi20210214101148.azurewebsites.net/api/search";
const SearchContext = React.createContext();

const SearchProvider = ({ children }) => {
  const [searchStatus, setSearchStatus] = useState(SEARCH_NOT_START);
  const [searchResults, setSearchResults] = useState([]);

  const fetchSearchResults = async (keywords, url, within, engines) => {
    setSearchStatus(SEARCH_LOADING);
    try {
      let enginesGroup = engines.join(" ");
      const address = `${apiUrl}?keywords=${keywords}&url=${url}&engines=${enginesGroup}&within=${within}`;
      console.log(address);
      const response = await fetch(address);
      const data = await response.json();
      if (data) {
        setSearchResults(data);
        setSearchStatus(SEARCH_SUCCESS);
      } else {
        setSearchResults([]);
        setSearchStatus(SEARCH_NO_RECORD);
      }
    } catch (error) {
      setSearchStatus(error.message);
    }
  };

  return (
    <SearchContext.Provider
      value={{
        searchResults,
        searchStatus,
        fetchSearchResults,
        setSearchStatus,
      }}
    >
      {children}
    </SearchContext.Provider>
  );
};
// make sure use
export const useSearchContext = () => {
  return useContext(SearchContext);
};

export { SearchContext, SearchProvider };
