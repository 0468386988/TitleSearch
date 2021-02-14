import React, { useState, useEffect } from "react";
import { useEngineContext } from "../context/engine_context";
import { useSearchContext } from "../context/search_context";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { Multiselect } from "multiselect-react-dropdown";
import ResultTable from "./ResultTable";

import "../App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import {
  SEARCH_NOT_START,
  API_NOT_FOUND,
  SEARCH_ENGINE_ERROR,
  SEARCH_SUCCESS,
  SEARCH_LOADING,
} from "../enums";

const TitleSearch = () => {
  const { engines, engineStatus } = useEngineContext();
  const {
    searchResults,
    searchStatus,
    fetchSearchResults,
    setSearchStatus,
  } = useSearchContext();
  const [keyWords, setKeyWords] = useState("online title search");
  const [url, setUrl] = useState("https://www.infotrack.com.au");
  const [within, setWithin] = useState(50);
  const [selectedEngines, setSelectedEngines] = useState([]);
  const [validated, setValidated] = useState(false);
  const [engineValidated, setEngneValidated] = useState(true);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (selectedEngines.length === 0) {
      setEngneValidated(false);
      return;
    } else {
      setEngneValidated(true);
    }

    const form = e.currentTarget;
    if (form.checkValidity() === false) {
      e.preventDefault();
      e.stopPropagation();
    } else {
      fetchSearchResults(keyWords, url, within, selectedEngines);
    }

    setValidated(true);
  };

  const multiSelectAction = (e) => {
    if (selectedEngines.length === 0) {
      setEngneValidated(false);
    } else {
      setEngneValidated(true);
    }
    setSelectedEngines(e);
  };

  useEffect(() => {
    setSelectedEngines(engines);
    setSearchStatus(engineStatus);
  }, [engines, engineStatus]);

  return (
    <div className="section-center">
      <Form onSubmit={handleSubmit} noValidate validated={validated}>
        <h3>Online Title Search</h3>
        <br />
        <Form.Group controlId="formBasicEmail">
          <Form.Label>Key words:</Form.Label>
          <Form.Control
            required
            type="text"
            placeholder="e.g. online title search"
            defaultValue={keyWords}
            onChange={(e) => setKeyWords(e.target.value)}
          />
          <Form.Control.Feedback type="invalid">
            Please fill in a key word.
          </Form.Control.Feedback>
        </Form.Group>
        <Form.Group controlId="formBasicPassword">
          <Form.Label>URL:</Form.Label>
          <Form.Control
            required
            type="text"
            placeholder="e.g. https://www.infotrack.com.au"
            defaultValue={url}
            onChange={(e) => setUrl(e.target.value)}
          />
          <Form.Control.Feedback type="invalid">
            Please fill in a URL.
          </Form.Control.Feedback>
        </Form.Group>
        <Form.Group controlId="exampleForm.ControlSelect1">
          <Form.Label>Within records number:</Form.Label>
          <Form.Control
            value={within}
            onChange={(e) => setWithin(e.target.value)}
            as="select"
          >
            <option>50</option>
            <option>100</option>
            <option>200</option>
          </Form.Control>
        </Form.Group>
        <Form.Group controlId="formBasicMultiSelect">
          <Form.Label>Engines:</Form.Label>
          <Multiselect
            options={engines}
            isObject={false}
            selectedValues={engines}
            value={selectedEngines}
            closeIcon="cancel"
            onSelect={multiSelectAction}
            onRemove={multiSelectAction}
          ></Multiselect>
          {engineValidated === false ? (
            <div className="invalidEngine">
              Please select at least one engine.
            </div>
          ) : null}
        </Form.Group>
        <br />
        <Button variant="primary" type="submit">
          GoooO
        </Button>
      </Form>
      <ResultTable
        SearchResults={searchResults}
        SearchStatus={searchStatus}
      ></ResultTable>
    </div>
  );
};

export default TitleSearch;
