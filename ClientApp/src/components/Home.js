import React, { Component } from "react";
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
        <br/>
        <SearchBar
          placeholder="Enter ORCID"
          className="search"
          onChange={(newValue) => console.log({ newValue })}
          onRequestSearch={() => console.log("searched")}
        />
      </div>
    );
  }
}
