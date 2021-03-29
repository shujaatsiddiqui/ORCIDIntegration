import React, { Component } from "react";
import Profile from "./Profile.jsx";
import { getUserEmploymentsInfo } from "../../api/RepoService";
import XMLParser from "react-xml-parser";
import { employment } from "../../Shared/employment";
import { works } from "../../Shared/works";

// This is my continer components that deals with all the logics
// and pass data as props
class ProfileContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Employments: employment,
      Works: works,
      UserProfile: {
        FullName: "",
        ORCID: 90090090 - 809890809,
      },
    };
  }

  componentDidMount() {
    debugger;
    getUserEmploymentsInfo("0000-0002-5807-5617")
      .then((res) => {
        // this.setState({
        //   Employments: new XMLParser().parseFromString(res),
        // });
      })
      .catch((error) => {
        alert(error);
      });
  }

  render() {
    return (
      <>
        <Profile
          Employments={this.state.Employments}
          Works={this.state.Works}
          UserProfile={this.state.UserProfile}
        />
      </>
    );
  }
}

export default ProfileContainer;
