import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import { Card, Divider } from "@material-ui/core";
import cx from "classnames";
import Collapse from "@kunukn/react-collapse";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";

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
    gridGap: theme.spacing(20),
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

const Work = (props) => {
  const [state, setState] = useState({
    isOpen1: false,
    isOpen2: false,
    isOpen3: false,
    spy3: {},
  });

  const toggle = (index) => {
    let collapse = "isOpen" + index;

    setState((prevState) => ({ [collapse]: !prevState[collapse] }));
  };

  const a = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  const b = [11, 12, 13, 14, 15, 16, 17];

  const classes = useStyles();

  const { Works } = props;

  console.log(Works);


  function getSecondPart(str) {
    return str.split('T')[0];
}

  return (
    <div className={classes.paper}>
      {/* WORK Section */}
      <button
        className={cx("app__toggle", {
          "app__toggle--active": state.isOpen1,
        })}
        onClick={() => toggle(1)}
      >
        <span className="app__toggle-text">WORK ({Works.length})</span>
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
        {Works.map((element, key) => (
          <Card className={classes.root}>
            <CardContent>
              <Paper elevation={3} className={classes.centered} >
                <Typography
                  className={classes.title}
                  color="textPrimary"
                  gutterBottom
                >
                  <strong style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word'}}>
                    {element["workWorkSummary"]["workTitle"].commonTitle}
                  </strong>
                </Typography>
                <Typography component="h2" style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word'}}>
                  {element["workWorkSummary"].workJournalTitle}
                </Typography>
                <Typography className={classes.pos} style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word'}}>
                  {
                    element["workWorkSummary"]["commonPublicationDate"]
                      .commonYear
                  }{" "}
                  | {element["workWorkSummary"].workType}
                  <br />
                  <Divider className={classes.divider} />
                  URL:{" "}
                  <a
                    href={element["workWorkSummary"].commonUrl}
                    target="_blank"
                  >
                    {element["workWorkSummary"].commonUrl}
                  </a>
                </Typography>

                <Grid spacing={1} className={classes.containers}>
                  <Grid item xs={8}>
                    <Typography>
                      <Typography>
                        <b>Added</b>
                      </Typography>
                      <Typography>
                        {getSecondPart(element["workWorkSummary"].commonCreatedDate)}
                      </Typography>
                    </Typography>
                  </Grid>
                  <Grid item xs={4}>
                    <Typography>
                      <Typography>
                        <b>Last modified</b>
                      </Typography>
                      <Typography >
                        {getSecondPart(element["workWorkSummary"].commonLastModifiedDate)}
                      </Typography>
                    </Typography>
                  </Grid>
                </Grid>

                <br />
                <Grid spacing={1} className={classes.containers}>
                  <Grid item xs={8}>
                    <Typography variant="body2" component="p">
                      <strong>Source:</strong>{" "}
                      {element["workWorkSummary"][
                        "commonSource"
                      ].commonSourceName.toUpperCase()}
                    </Typography>
                  </Grid>
                  <Grid item xs={4}>
                    <Typography variant="body2" component="p">
                      <FaStar />
                      Preferred source
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

export default Work;
