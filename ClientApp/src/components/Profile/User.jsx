import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Paper from "@material-ui/core/Paper";
import Divider from "@material-ui/core/Divider";
// import Grid from "@material-ui/core/Grid";

import { GrCircleInformation } from "react-icons/gr";

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

function User(props) {
  const classes = useStyles();
  return (
    <>
      <Paper elevation={0} className={classes.paper}>
        <Paper elevation={0}>
          <Typography>
            <h2
              className={classes.text}
              style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word',color: "#6A0919", textAlign: "justify" }}
            >
              Shujaat Siddiqui
            </h2>
          </Typography>
        </Paper>
        <Paper
          elevation={0}
          className={classes.border}
          className={classes.border}
        >
          <Typography style={{ textAlign: "justify" }}>
            <h4
              className={classes.text}
              style={{
                background: "#6A0919",
                // background: "#2D1316",
                textAlign: "justify",
                color: "white",
              }}
            >
              ORCID iD
            </h4>
            <h6 style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word'}}>
              <GrCircleInformation /> https://orcid.org/0000-0003-0871-1387
            </h6>
          </Typography>
        </Paper>
        <br />
        <Typography style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word', textAlign: "left" }}>
          <span>
            <strong>
              <b>Other IDs</b>
            </strong>{" "}
            <br />
            Scopus Author ID: 55538861800 <br />
            <b>Sources:</b> Shujaat Siddiqui via Scopus - <br />
            Elsevier 2021-01-12
          </span>
        </Typography>
        <Divider className={classes.divider} />
        <Typography style={{whiteSpace: 'pre-wrap', overflowWrap: 'break-word', textAlign: "left" }}>
          <span>
            <strong>
              <b>Email</b>
            </strong>{" "}
            <br />
            shujaatsiddiqui91@gmail.com <br />
            std_21952@iobm.edu.pk <br />
          </span>
        </Typography>
      </Paper>
    </>
  );
}

export default User;