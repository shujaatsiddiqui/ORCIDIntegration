import React, { Component } from "react";
import Profile from "./Profile";
import { getUserDetails, fetchUserDetails } from "../../api/RepoService";
import { employment } from "../../Shared/employment";
import { works } from "../../Shared/works";
import ReactLoading from "react-loading";

// This is my continer components that deals with all the logics
// and pass data as props
class ProfileContainer extends Component {
  constructor(props) {
    debugger;
    super(props);

    this.OnFetchClick = this.OnFetchClick.bind(this);
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

  OnFetchClick = () => {
    debugger;
    const { orcid } = this.props;
    this.setState({
      isLoading: true,
    });
    fetchUserDetails(orcid)
      .then((res) => {
        this.setState({
          Employments:
            res.recordRecord.activitiesActivitiesSummary.activitiesEmployments
              .activitiesAffiliationGroup,
          Works:
            res.recordRecord.activitiesActivitiesSummary.activitiesWorks
              .activitiesGroup,
          UserProfile: {
            ...this.state.UserProfile,
            FullName: "shujaat siddiqui",
          },
          isLoading: false,
        });
      })
      .catch((error) => {
        alert("Invalid ORCID");
      });
  };

  componentDidMount() {
    //debugger;
    const { orcid } = this.props;
    getUserDetails(orcid)
      .then((res) => {
        this.setState({
          Employments:
            res.recordRecord.activitiesActivitiesSummary.activitiesEmployments
              .activitiesAffiliationGroup,
          Works:
            res.recordRecord.activitiesActivitiesSummary.activitiesWorks
              .activitiesGroup,
          UserProfile: {
            ...this.state.UserProfile,
            FullName:
              res.recordRecord.personPerson.personName
                .personalDetailsGivenNames +
              " " +
              res.recordRecord.personPerson.personName
                .personalDetailsFamilyName,
          },
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
            OnFetchClick={this.OnFetchClick}
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
