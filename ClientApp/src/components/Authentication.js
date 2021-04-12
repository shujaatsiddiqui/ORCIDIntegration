import React, { Component } from "react";
import queryString from "query-string";
import { GetAccessTokenFromCode } from "../api/RepoService";
import ReactLoading from "react-loading";
import { Link } from "react-router-dom";

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
          <ReactLoading
            type={"spin"}
            color={"black"}
            height={"50px"}
            width={"50px"}
          />
        ) : (
          <div className="row">
            <div className="col-md-6 col-md-offset-3">
              <h3>
                {/* <span>Token Has Been Saved Successfully: </span> */}
                {this.state.data}
              </h3>
              <Link to="/home">Click Here</Link>
            </div>
          </div>
        )}
      </div>
    );
  }

  async SaveDataToDB(code) {

    GetAccessTokenFromCode(code)
    .then((res) => {
      //debugger;
      this.setState({
        data: "You have been successfully registered.",
        loading: false
      });
    })
    .catch((error) => {
      //debugger;
      this.setState({
        data: error.data.error_description,
        loading: false
      });
    });

    //debugger;
  //   const requestOptions = {
  //     method: "POST",
  //     headers: { "Content-Type": "application/json" },
  //     body: JSON.stringify({ code: accessToken }),
  //   };
  //   const response = await fetch(
  //     "/api/OrcidIntegration/accesstoken/",
  //     requestOptions
  //   );
  //   var data = new Object();
  //   debugger;
  //   data = await response.json();
  //   this.setState({ data: Object.entries(data)[0][1], loading: false });
  //   console.log(data.accessToken);
  // }
  }
}
