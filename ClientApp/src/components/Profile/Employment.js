import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import { Card } from "@material-ui/core";
import cx from "classnames";
import Collapse from "@kunukn/react-collapse";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Divider from "@material-ui/core/Divider";

import { FaStar } from "react-icons/fa";

const useStyles = makeStyles((theme) => ({
  container: {
    display: "grid",
    gridTemplateColumns: "repeat(12, 1fr)",
    gridGap: theme.spacing(2),
  },
  containers: {
    display: "grid",
    gridTemplateColumns: "repeat(12, 1fr)",
    gridGap: theme.spacing(30),
  },
  paper: {
    padding: theme.spacing(1),
    textAlign: "center",
    color: theme.palette.text.secondary,
    whiteSpace: "nowrap",
    marginBottom: theme.spacing(1),
  },
  centered: {
    padding: theme.spacing(2),
    fontFamily: "Noto Sans, sans-serif",
  },
  divider: {
    margin: theme.spacing(2, 0),
  },

  root: {
    minWidth: "100%",
    textAlign: "left",
    // border: "0.2 px solid",
  },
  bullet: {
    display: "inline-block",
    margin: "0 2px",
    transform: "scale(0.8)",
  },
  title: {
    fontSize: 14,
  },
  pos: {
    marginBottom: 12,
  },
}));

const Employment = (props) => {
  // console.log(props.Emloyements)
  const [state, setState] = useState({
    isOpen1: false,
    isOpen2: false,
    isOpen3: false,

    spy3: {},
  });

  const [ab, setAb] = useState({
    open: false,
  });

  const toggle = (index) => {
    let collapse = "isOpen" + index;

    setState((prevState) => ({ [collapse]: !prevState[collapse] }));
  };
  const toggle2 = () => {
    let collapse = "open";

    setAb((prevState) => ({ [collapse]: !prevState[collapse] }));
    console.log(ab);
  };

  const a = [1, 2];

  const x = a.length;
  const { Employments } = props;
  // debugger;
  // console.log((1+1).toString()+'bbb')
  // console.log(Employments["affiliation-group"])

  const classes = useStyles();

  return (
    <div className={classes.paper}>
      <button
        className={cx("app__toggle", {
          "app__toggle--active": state.isOpen1,
        })}
        onClick={() => toggle(1)}
      >
        <span className="app__toggle-text">
          Employment ({Employments.length})
        </span>
        <div className="rotate90">
          <svg
            className={cx("icon", { "icon--expanded": state.isOpen1 })}
            viewBox="6 0 12 24"
            style={{ background: "white" }}
          >
            <polygon points="8 0 6 1.8 14.4 12 6 22.2 8 24 18 12" />
          </svg>
        </div>
      </button>
      <Collapse
        isOpen={state.isOpen1}
        className={
          "app__collapse app__collapse--gradient " +
          (state.isOpen1 ? "app__collapse--active" : "")
        }
      >
        {Employments.map((element, key) => (
          <Card key={key} className={classes.root}>
            <CardContent>
              <Paper elevation={3} className={classes.centered}>
                <Typography
                  variant="body2"
                  component="p"
                  className={classes.title}
                  gutterBottom
                >
                  <strong>
                    {element["employmentEmploymentSummary"][
                      "commonOrganization"
                    ].commonName.toUpperCase()}
                    :{" "}
                    {
                      element["employmentEmploymentSummary"][
                        "commonOrganization"
                      ]["commonAddress"].commonCity
                    }
                    ,{" "}
                    {
                      element["employmentEmploymentSummary"][
                        "commonOrganization"
                      ]["commonAddress"].commonRegion
                    }
                    ,{" "}
                    {
                      element["employmentEmploymentSummary"][
                        "commonOrganization"
                      ]["commonAddress"].commonCountry
                    }
                  </strong>

                </Typography>
                <Typography variant="h5" component="h2"></Typography>
                <Typography className={classes.pos}>
                  {
                    element["employmentEmploymentSummary"]["commonStartDate"]
                      .commonYear
                  }
                  -
                  {
                    element["employmentEmploymentSummary"]["commonStartDate"]
                      .commonMonth
                  }
                  -
                  {
                    element["employmentEmploymentSummary"]["commonStartDate"]
                      .commonDay
                  }{" "}
                  <strong>to</strong>{" "}
                  {
                    // element["employmentEmploymentSummary"]["commonEndDate"]
                    //   .commonYear
                  }
                  -
                  {
                    // element["employmentEmploymentSummary"]["commonEndDate"]
                    //   .commonMonth
                  }
                  -
                  {
                    // element["employmentEmploymentSummary"]["commonEndDate"]
                    //   .commonDay
                  }{" "}
                  | {element["employmentEmploymentSummary"]["commonRoleTitle"]}{" "}
                  ({element["employmentEmploymentSummary"].commonDepartmentName}
                  )
                  <br />
                  Employment
                </Typography>
                <Divider className={classes.divider} />
                <Grid spacing={1} className={classes.containers}>
                  <Grid item xs={8}>
                    <Typography>
                      <Typography>
                        <b>Added</b>
                      </Typography>
                      <Typography>
                        {
                          element["employmentEmploymentSummary"].commonCreatedDate
                        }
                      </Typography>
                    </Typography>
                  </Grid>
                  <Grid item xs={4}>
                    <Typography>
                      <Typography>
                        <b>Last modified</b>
                      </Typography>
                      <Typography>
                        {
                         element["employmentEmploymentSummary"].commonLastModifiedDate
                        }
                      </Typography>
                    </Typography>
                  </Grid>
                </Grid>

                <br />

                <Grid spacing={1} className={classes.containers}>
                  <Grid item xs={8}>
                    <Typography variant="body2" component="p">
                      <strong>Source: </strong>
                      {element["employmentEmploymentSummary"][
                        "commonSource"
                      ].commonSourceName.toUpperCase()}
                    </Typography>
                  </Grid>
                  <Grid item xs={4}>
                    <Typography variant="body2" component="p">
                      <FaStar /> Preferred source
                    </Typography>
                  </Grid>
                </Grid>
              </Paper>
            </CardContent>
          </Card>
        ))}
      </Collapse>
    </div>
  );
};

export default Employment;
