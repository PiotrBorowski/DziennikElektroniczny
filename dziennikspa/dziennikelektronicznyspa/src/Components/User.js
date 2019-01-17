import React, { Component } from "react";
import "../Styles/Page.css"
import {ButtonGroup, UncontrolledCollapse, Button, CardBody, Card } from 'reactstrap';

export default class User extends Component{
    constructor(props){
        super(props);
        this.state = {
            userId: this.props.userId,
            name: this.props.name,
            surName: this.props.surName,
            phoneNumber: this.props.phoneNumber,
            roleId: this.props.roleId
        };
    }

    toggleModal = () =>{
        this.setState({
          modal: !this.state.modal
        });
      }

    render(){

        function Role(props)
        {
            switch(props.roleId)
            {
                case 1:
                    return <span >Admin</span>
                case 2:
                    return <span >Teacher</span>
                case 3:
                    return <span >Parent</span>
                case 4:
                    return <span >Student</span>
                default:
                    return <span >Undefined</span>
            }          
        }

        return (
            <div className="page" >
         
                <h5 className="text-center text-truncate">
                    <span>{this.props.name} </span>
                    <span>{this.props.surName}</span>

                </h5>
                <div className="btn btn-dark btn-block" id={"toggler" + this.props.userId} >
                    Więcej
                </div>
                <UncontrolledCollapse toggler={"#toggler"+this.props.userId}>
                    <Card>
                        <CardBody>
                         <div className="col-lg-4">
                            <span style={{"fontWeight":"normal"}}>Phone Number: </span><time>{this.props.phoneNumber}</time><br/>
                            <span style={{"fontWeight":"normal"}}>Role </span>{Role(this.props)}<br/><br/>
                        </div>
                        </CardBody>
                    </Card>
                </UncontrolledCollapse>
            </div>
        )
    }

}