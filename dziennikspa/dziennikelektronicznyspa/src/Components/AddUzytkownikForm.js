import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddUzytkownikForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            name: "",
            surName: "",
            phoneNumber: "",
            roleId: 0
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

    handleUserInputRoleId = e =>{
        this.setState({roleId: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();

        this.sendRequest();
        

    }

    sendRequest = () => {
        axios.post(BASE_URL + "/admin", {
            Imie: this.state.name,
            Nazwisko: this.state.surName,
            NumerKontaktowy: this.state.phoneNumber,
            IdRoli: this.state.roleId
        }).then((response) => { 
            console.log(response);
            console.log("DUPA");
        }, (error) => {
            console.log(error);

            if(error.response.status === 400){
                this.refs.url.style.borderColor = "red";
            }
        }
        )
    }


    render(){
        return (
        <div className="form-center">
        <form onSubmit={this.handleSubmit}>
            <h2 className="title">Add new user</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Name</span>
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
                        <span class="input-group-text" id="inputGroup-sizing-default">Surname</span>
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
                        <span class="input-group-text" id="inputGroup-sizing-default">Phone number</span>
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
                        <label class="input-group-text" for="inputGroupSelect01">Role</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputRoleId}>
                        <option selected value="1">Admin</option>
                        <option value="2">Teacher</option>
                        <option value="3">Parent</option>
                        <option value="4">Student</option>
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
                        Submit
                    </button>
                </div>
            </div>
            </form>
        </div>
        )
    }
}