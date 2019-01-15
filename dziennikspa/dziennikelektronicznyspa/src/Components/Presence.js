import React, { Component } from "react";
import "../Styles/Page.css"
import axios from "axios"
import {BASE_URL} from "../constants"
import {ButtonGroup, UncontrolledCollapse, Button, CardBody, Card } from 'reactstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {  Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export default class Presence extends Component{
    constructor(props){
        super(props);
        this.state = {
            surname: this.props.surname,
            name: this.props.name,
            studentId: this.props.studentId
        };
    }


    sendRequest = () => {
        axios.post(BASE_URL + "/teacher/dodajObecnosc", {
            czyObecny: true,
            idUcznia: this.state.studentId,
            IdListy: this.props.lessonId
        }).then((response) => { 
            console.log(response);
            this.props.history.push('/');
        }, (error) => {
            console.log(error);

        }
        )
    }

    present = () => {
        axios.post(BASE_URL + "/teacher/dodajObecnosc", {
            czyObecny: true,
            idUcznia: this.state.studentId,
            IdListy: this.props.lessonId
        }).then((response) => { 
            console.log(response);
        }, (error) => {
            console.log(error);

        }
        )
    }

    absent = () => {
        axios.post(BASE_URL + "/teacher/dodajObecnosc", {
            czyObecny: false,
            idUcznia: this.state.studentId,
            IdListy: this.props.lessonId
        }).then((response) => { 
            console.log(response);
        }, (error) => {
            console.log(error);

        }
        )
    }

    render(){

        return (
            <div className="page" >
               
                <h5 className="text-center text-truncate">
                    <span>{this.props.name} </span>
                    <span>{this.props.surname}</span>
                </h5>

                <div className="row">
                <div className="col-sm-1">
                    <button onClick={this.present} className="btn btn-primary">OBECNY</button>                   
                </div>
                <div className="col-sm-1 offset-1">
                    <button onClick={this.absent} className="btn btn-danger">NIEOBECNY</button>                   
                </div>
                </div>

            </div>
        )
    }

}