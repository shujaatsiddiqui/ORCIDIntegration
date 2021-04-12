import React, { Component } from "react";
import Profile from "./Profile";
import { getUserDetails } from "../../api/RepoService";
import { employment } from "../../Shared/employment";
import { works } from "../../Shared/works";
import ReactLoading from "react-loading";

// This is my continer components that deals with all the logics
// and pass data as props
class ProfileContainer extends Component {
  constructor(props) {
    debugger;
    super(props);
    this.state = {
      isLoading: true,
      Employments: [],
      Works: [],
      UserProfile: {
        FullName: "",
        ORCID: this.props.orcid,
      },
    };
  }

  componentDidMount() {
    //debugger;
    const { orcid } = this.props;
    getUserDetails(orcid)
      .then((res) => {
        //debugger;
        this.setState({
          Employments:
            res.recordRecord.activitiesActivitiesSummary.activitiesEmployments
              .activitiesAffiliationGroup,
          Works:
            res.recordRecord.activitiesActivitiesSummary.activitiesWorks
              .activitiesGroup,
          UserProfile: { ...this.state.UserProfile, FullName: "shujaat siddiqui" },
          isLoading: false,
        });
      })
      .catch((error) => {
        alert("Invalid ORCID");
      });
  }

  render() {
    return (
      <>
        {this.state.isLoading == false ? (
          <Profile
            Employments={this.state.Employments}
            Works={this.state.Works}
            UserProfile={this.state.UserProfile}
          />
        ) : (
          <ReactLoading
            type={"spin"}
            color={"black"}
            height={"50px"}
            width={"50px"}
          />
        )}
      </>
    );
  }
}

export default ProfileContainer;
