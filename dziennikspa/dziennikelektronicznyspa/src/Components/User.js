import React, { Component } from "react";
import "../Styles/Page.css"
import axios from "axios"
import {BASE_URL} from "../constants"
import {ButtonGroup, UncontrolledCollapse, Button, CardBody, Card } from 'reactstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {  Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

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
                <Modal isOpen={this.state.modal} toggle={this.toggle}>
                <ModalHeader toggle={this.toggleModal}>Confirm</ModalHeader>
                <ModalBody>
                    Do you really want to delete this user?
                </ModalBody>
                <ModalFooter>
                    <Button color="danger" onClick={() => this.props.onDelete(this.props.pageId)}>Delete</Button>
                    <Button color="secondary" onClick={this.toggleModal}>Cancel</Button>
                </ModalFooter>
                </Modal>
           
                <h5 className="text-center text-truncate">
                    <span>{this.props.name} </span>
                    <span>{this.props.surName}</span>

                </h5>
                <div className="row">         
                    <div className="col-lg">
                    <ButtonGroup className="float-right">
                        <button className="btn" onClick={() => this.toggleModal()}>                                 
                            <FontAwesomeIcon icon="trash" color="black" aria-hidden="true"/>
                        </button>
                    </ButtonGroup>
                    </div>
                </div>
                <div className="btn btn-dark btn-block" id={"toggler" + this.props.userId} >
                    More Info
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