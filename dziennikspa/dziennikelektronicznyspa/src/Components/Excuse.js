import React, { Component } from "react";
import "../Styles/Page.css"
import axios from "axios"
import {BASE_URL} from "../constants"
import {ButtonGroup, UncontrolledCollapse, Button, CardBody, Card } from 'reactstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {  Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export default class Excuse extends Component{
    constructor(props){
        super(props);
        this.state = {
            id: this.props.id,
            text: this.props.text,
            date: this.props.date,
            accepted: this.props.accepted
        };
    }

    accept = () => {
        axios.post(BASE_URL + "/teacher/akceptujUsprawiedliwienie?id="+this.props.id).then((response) => { 
            console.log(response);
        }, (error) => {
            console.log(error);

        }
        )
    }

    discard = () => {
        axios.post(BASE_URL + "/teacher/odrzucUsprawiedliwienie?id="+this.props.id
        ).then((response) => { 
            console.log(response);
        }, (error) => {
            console.log(error);

        }
        )
    }


    Excused(excused)
    {
        switch(excused)
        {
            case true:
                return <span className="green">Usprawiedliwione</span>
            case false:
                return <span className="red">Odrzucone</span>
            default:
                return <span >Nierozpatrzone</span>
        }          
    }

    render(){

        return (
            <div className="page" >
               
                <h5 className="text-center text-truncate">
                    <span>{this.props.date} </span>
                    {this.Excused(this.props.accepted)}
                </h5>
                <p>
                <span>{this.props.text}</span>
                </p>
                <div className="row">
                <div className="col-sm-1">
                    <button onClick={this.accept} className="btn btn-primary">Akceptuj</button>                   
                </div>
                <div className="col-sm-1 offset-1">
                    <button onClick={this.discard} className="btn btn-danger">Odrzuć</button>                   
                </div>
                </div>

            </div>
        )
    }

}