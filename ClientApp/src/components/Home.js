import React, { Component } from 'react';
import {
  Card, CardImg, CardText, CardBody,
  CardTitle, CardSubtitle, Button
} from 'reactstrap';


export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div className="container" style={{width:"40%", height:"40%"}}> 
       <Card>
          <CardImg top width="100%" src="/logo.png" alt="Card image cap" />
            <CardBody>
              <CardTitle tag="h5">IOBM</CardTitle>
              <CardText>Integration of IOBM with ORCID</CardText>
          </CardBody>
        </Card>
      </div>
    );
  }
}
