import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddExcuseForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            text: "",
            userId: 0,
            date: 0
        };
    }

    handleUserInputText = e =>{
        this.setState({text: e.target.value});
    }

    handleUserInputUserId = e =>{
        this.setState({userId: e.target.value});
    }

    handleUserInputDate = e =>{
        this.setState({date: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/parent/dodajUsprawiedliwienie", {
            Tresc: this.state.text,
            IdWychowawcy: this.state.userId,
            Data: this.state.date
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
            <h2 className="title">Dodaj usprawiedliwienie</h2>
            <div className="form-group col-md-10 offset-md-1">
        
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


                   <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Data</span>
                    </div>
                    <input
                        className="form-control"
                        type="date"
                        name="date"
                        ref="date"
                        value={this.state.date}
                        onChange={this.handleUserInputDate}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Nauczyciel:</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputUserId}>
                        <option value=''></option>
                        <option value="6">Nauczyciel 6</option>
                        <option  value="13">Nauczyciel 13</option>
                    </Input>
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