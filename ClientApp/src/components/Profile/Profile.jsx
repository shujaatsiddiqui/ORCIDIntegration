// This is my preseentational components that deals with all the UI Implementations
import React, { Component }  from 'react';
import JSONPretty from 'react-json-prettify';

export default function Profile(props) {
  debugger;
  const {Employments,Works} = props;
  return (
    <>
    <span>{Employments["last-modified-date"]}</span>
      {/* <JSONPretty json={Employments} /> */}
    </>
  );
}
