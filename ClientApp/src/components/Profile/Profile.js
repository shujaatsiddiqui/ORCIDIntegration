import React from "react";

import { makeStyles } from "@material-ui/core/styles";

import Paper from "@material-ui/core/Paper";

import Grid from "@material-ui/core/Grid";
import Employment from "./Employment";
import Work from "./Work";
import User from "./User";
import { Typography } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  container: {
    display: "grid",
    gridTemplateColumns: "repeat(12, 1fr)",
    gridGap: theme.spacing(1),
  },
  paper: {
    padding: theme.spacing(1),
    textAlign: "center",
    // color: theme.palette.text.secondary,
    whiteSpace: "nowrap",
    marginBottom: theme.spacing(0),
  },
  divider: {
    margin: theme.spacing(2, 0),
  },
  text: {
    padding: theme.spacing(0.5),
  },
  papers: {
    padding: theme.spacing(0.6),
  },

  border: {
    borderBottom: "1px solid #2D1316",
    borderRight: "1px solid #2D1316",
    borderLeft: "1px solid #2D1316",
  },
}));

function Profile(props) {
  const classes = useStyles();
  const { Employments, Works, UserProfile } = props;
  //debugger;
  return (
    <Grid container xs={12} spacing={2}>
      <Grid item xs={4}>
        <User UserProfile={UserProfile} />
      </Grid>
      <Grid item xs={8}>
        <Paper elevation={0} className={classes.papers}>
          <Employment Employments={Employments} />
          <Work Works={Works} />
        </Paper>
        <Typography>
          <span style={{fontSize: 'x-small',paddingLeft: '15px'}}><strong>Record last modified</strong> Mar 15, 2021 9:21:14 PM</span>
        </Typography>
      </Grid>
    </Grid>
  );
}

export default Profile;
