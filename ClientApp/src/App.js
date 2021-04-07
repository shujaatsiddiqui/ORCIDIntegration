import React, { Component } from "react";
import { Redirect, Route, Switch } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { Authentication } from "./components/Authentication";
//here calling my container component
import Profile from "./components/Profile";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Switch>
          <Route exact path="/home" component={Home} />
          <Route path="/counter" component={Counter} />
          <Route path="/fetch-data" component={FetchData} />
          <Route path="/accesstoken" component={Authentication} />
          <Route
            exact
            path="/profile/:orcid"
            component={({ match }) => <Profile orcid={match.params.orcid} />}
          />
          {/* <Redirect to="/home" /> */}
        </Switch>
      </Layout>
    );
  }
}
