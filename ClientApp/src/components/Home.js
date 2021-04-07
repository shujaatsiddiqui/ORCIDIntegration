import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import {
  Card,
  CardImg,
  CardText,
  CardBody,
  CardTitle,
  CardSubtitle,
  Button,
} from "reactstrap";

import SearchBar from "material-ui-search-bar";

export class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      value: "",
    };
  }

  static displayName = Home.name;

  render() {
    return (
      <div className="container" style={{ width: "40%", height: "40%" }}>
        <Card>
          <CardImg
            top
            height="50%"
            src="/logo.png"
            alt="Card image cap"
            style={{ width: "50%", margin: "auto" }}
          />
          <CardBody>
            <CardTitle tag="h5">IOBM</CardTitle>
            <CardText>Integration of IOBM with ORCID</CardText>
          </CardBody>
        </Card>
        <br />
        <SearchBar
          placeholder="Enter ORCID"
          className="search"
          value={this.state.value}
          onChange={(newValue) => this.setState({ value: newValue })}
          onRequestSearch={() =>
            this.props.history.push("profile/" + this.state.value)
          }
        />
      </div>
    );
  }
}
