import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddKlasaForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            subjectId: 0,
            categoryId: 0,
            userId: 0,
            value: 0,
        };
    }

    handleUserInputSubject = e => {
        this.setState({ subjectId: e.target.value });
    }

    handleUserInputCategory = e =>{
        this.setState({categoryId: e.target.value});
    }

    handleUserInputUser = e =>{
        this.setState({userId: e.target.value});
    }

    handleUserInputValue = e =>{
        this.setState({value: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/teacher/dodajOcene", {
            Wartosc: this.state.value,
            IdPrzedmiotu: this.state.subjectId,
            IdKategoriiOceny: this.state.categoryId,
            IdUcznia: this.state.userId
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
            <h2 className="title">Dodaj nową ocenę</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Ocena</span>
                    </div>
                    <input
                        className="form-control"
                        type="number"
                        name="ocena"
                        ref="ocena"
                        min='1'
                        step='0.5'
                        max='6'
                        value={this.state.value}
                        onChange={this.handleUserInputValue}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Przedmiot</span>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputSubject}>
                        <option selected value=''></option>
                        <option value="1">Przedmiot 1</option>
                        <option value="2">Przedmiot 2</option>
                    </Input>
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Kategoria</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputCategory}>
                        <option selected value=''></option>
                        <option value="1">Koncowa</option>
                        <option value="2">Proponowana</option>
                        <option value="3">Klasówka</option>
                        <option value="5">Test</option>
                        <option value="6">Kartkówka</option>
                        <option value="7">Odpowiedź Ustna</option>
                    </Input>
                </div>        
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Uczen</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputUser}>
                        <option selected value=''></option>
                        <option value="7">Uczen 7</option>
                        <option value="2">Uczen 2</option>
                        <option value="15">Uczen 15</option>
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
                        Dodaj
                    </button>
                </div>
            </div>
            </form>
        </div>
        )
    }
}