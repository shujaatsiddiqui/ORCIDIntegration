import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { Authentication } from "./components/Authentication";
//here calling my container component
import Profile from "./components/Profile";
import './App.css';
import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <Route path="/fetch-data" component={FetchData} />
        <Route path="/accesstoken" component={Authentication} />
        <Route path="/profile" component={Profile} />
      </Layout>
    );
  }
}
