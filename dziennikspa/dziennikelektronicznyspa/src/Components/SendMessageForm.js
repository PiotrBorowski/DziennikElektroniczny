import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddSubjectForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            text: "",
            userId: 0
        };
    }

    handleUserInputText = e =>{
        this.setState({text: e.target.value});
    }

    handleUserInputUserId = e =>{
        this.setState({userId: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/user/dodajWiadomosc", {
            Tresc: this.state.text,
            IdOdbiorcy: this.state.userId
        }).then((response) => { 
            console.log(response);
            this.props.history.push('/');
        }, (error) => {
            console.log(error);

            this.props.history.push('/');
        }
        )
    }


    render(){
        return (
        <div className="form-center">
        <form onSubmit={this.handleSubmit}>
            <h2 className="title">Wyślij wiadomosc</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Odbiorca ID</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="userid"
                        ref="userid"
                        value={this.state.userId}
                        onChange={this.handleUserInputUserId}
                        required
                        />
                </div>
            
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Treść</label>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="tresc"
                        ref="tresc"
                        value={this.state.text}
                        onChange={this.handleUserInputText}
                        required
                        />
                </div>                
            </div>
                    
            <div className="row">
                <div className="col-sm-4 button-form">
                    <button
                        type="submit"
                        id="submitButton"
                        className="btn btn-dark"                        
                    >
                        Wyślij
                    </button>
                </div>
            </div>
            </form>
        </div>
        )
    }
}