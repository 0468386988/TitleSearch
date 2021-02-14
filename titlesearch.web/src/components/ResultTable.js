import React, { useState, useEffect } from "react";
import Table from "react-bootstrap/Table";
import Spinner from "react-bootstrap/Spinner";

import "bootstrap/dist/css/bootstrap.min.css";
import { SEARCH_SUCCESS, SEARCH_LOADING } from "../enums";

const ResultTable = ({ SearchResults, SearchStatus }) => {
  switch (SearchStatus) {
    case SEARCH_LOADING:
      return (
        <div>
          <br />
          <Spinner animation="border" variant="primary" />
        </div>
      );
      break;
    case SEARCH_SUCCESS:
      return (
        <div>
          <br />
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Engine</th>
                <th>Positions</th>
              </tr>
            </thead>
            <tbody>
              {SearchResults.map((result, index) => {
                return (
                  <tr key={index}>
                    <td>{result.item1}</td>
                    <td>{result.item2}</td>
                  </tr>
                );
              })}
            </tbody>
          </Table>
        </div>
      );
      break;

    default:
      return (
        <div>
          <br />
          <h3>{SearchStatus}</h3>
        </div>
      );
      break;
  }
};

export default ResultTable;
