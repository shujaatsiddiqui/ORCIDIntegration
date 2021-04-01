import React, { Component } from "react";
import queryString from "query-string";
import { convertCompilerOptionsFromJson } from "typescript";

export class Authentication extends Component {
  componentDidMount() {
    let params = queryString.parse(this.props.location.search);
    let accessToken = params.code;
    this.SaveDataToDB(accessToken);
  }

  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      data: "",
    };
  }

  render() {
    return (
      <div className="container">
        {this.state.loading ? (
          <div>loading..</div>
        ) : (
          <h2>
            <span>Token Has Been Saved Successfully: </span>
            {this.state.data}
          </h2>
        )}
      </div>
    );
  }

  async SaveDataToDB(accessToken) {
    debugger;
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ code: accessToken }),
    };
    const response = await fetch(
      "/api/OrcidIntegration/accesstoken/",
      requestOptions
    );
    var data = new Object();
    data = await response.json();
    this.setState({ data: Object.entries(data)[0][1], loading: false });
    console.log(data.accessToken);
  }
}
