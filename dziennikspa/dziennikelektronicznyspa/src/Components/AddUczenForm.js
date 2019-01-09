import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddUczenForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            name: "",
            surName: "",
            phoneNumber: "",
            roleId: 4,
            pesel: "",
            parentId: 0,
            classId: 0
        };
    }

    handleUserInputPhoneNumber = e => {
        this.setState({ phoneNumber: e.target.value });
    }

    handleUserInputSurName = e => {
        this.setState({ surName: e.target.value });
    }

    handleUserInputName = e =>{
        this.setState({name: e.target.value});
    }

    handleUserInputPesel = e =>{
        this.setState({pesel: e.target.value});
    }

    handleUserInputParentId = e =>{
        this.setState({parentId: e.target.value});
    }

    handleUserInputClassId = e =>{
        this.setState({classId: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();

        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/admin/dodajUcznia", {
            Imie: this.state.name,
            Nazwisko: this.state.surName,
            NumerKontaktowy: this.state.phoneNumber,
            IdRoli: this.state.roleId,
            Pesel: this.state.pesel,
            IdRodzica: this.state.parentId,
            IdKlasy: this.state.classId
        }).then((response) => { 
            console.log(response);
            this.props.history.push('/');
        }, (error) => {
            console.log(error);

            if(error.response.status === 400){
                this.refs.name.style.borderColor = "red";
            }
        }
        )
    }


    render(){
        return (
        <div className="form-center">
        <form onSubmit={this.handleSubmit}>
            <h2 className="title">Dodaj nowego ucznia</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Imię</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="name"
                        ref="name"
                        value={this.state.name}
                        onChange={this.handleUserInputName}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Nazwisko</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="surName"
                        ref="surName"
                        value={this.state.surName}
                        onChange={this.handleUserInputSurName}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Numer telefonu</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="phoneNumber"
                        ref="phoneNumber"
                        value={this.state.phoneNumber}
                        onChange={this.handleUserInputPhoneNumber}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">PESEL</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="pesel"
                        ref="pesel"
                        value={this.state.pesel}
                        onChange={this.handleUserInputPesel}
                        required
                        />
                </div>      
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Rodzic</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputParentId}>
                    <option value=''></option>
                        <option selected value="1">Rodzic 1</option>
                        <option value="2">Rodzic 2</option>
                        <option value="3">Rodzic 3</option>
                        <option value="4">Rodzic 4</option>
                    </Input>
                </div>  
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Klasa</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputClassId}>
                    <option value=''></option>
                        <option value="1">Klasa 1</option>
                        <option value="2">Klasa 2</option>
                        <option value="3">Klasa 3</option>
                        <option value="4">Klasa 4</option>
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