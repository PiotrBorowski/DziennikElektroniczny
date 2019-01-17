import React, { Component } from "react";
import "../Styles/Page.css"
import {ButtonGroup, UncontrolledCollapse, Button, CardBody, Card } from 'reactstrap';

export default class User extends Component{
    constructor(props){
        super(props);
        this.state = {
            classId: this.props.classId,
            name: this.props.name,
            year: this.props.year,
            teacherId: this.props.teacherId
        };
    }

    toggleModal = () =>{
        this.setState({
          modal: !this.state.modal
        });
      }

    render(){

        return (
            <div className="page" >
           
                <h5 className="text-center text-truncate">
                    <span>{this.props.name} </span>
                    <span>{this.props.year}</span>

                </h5>

                <div className="btn btn-dark btn-block" id={"toggler" + this.props.classId} >
                    Więcej
                </div>
                <UncontrolledCollapse toggler={"#toggler"+this.props.classId}>
                    <Card>
                        <CardBody>
                         <div className="col-lg-4">
                            <span style={{"fontWeight":"normal"}}>Teacher ID: </span><time>{this.props.teacherId}</time><br/>
                        </div>
                        </CardBody>
                    </Card>
                </UncontrolledCollapse>
            </div>
        )
    }

}