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
            name: "",
            year: "",
            teacherId: 0
        };
    }

    handleUserInputYear = e => {
        this.setState({ year: e.target.value });
    }

    handleUserInputName = e =>{
        this.setState({name: e.target.value});
    }

    handleUserInputTeacherId = e =>{
        this.setState({teacherId: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/admin/dodajKlase", {
            Nazwa: this.state.name,
            RokSzkolny: this.state.year,
            IdWychowawcy: this.state.teacherId
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
            <h2 className="title">Dodaj nową klasę</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Nazwa</span>
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
                        <span class="input-group-text" id="inputGroup-sizing-default">Rok Szkolny</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="year"
                        ref="year"
                        value={this.state.year}
                        onChange={this.handleUserInputYear}
                        required
                        />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Wychowawca</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputTeacherId}>
                        <option value=''></option>
                        <option value="6">Wychowawca 6</option>
                        <option  value="13">Wychowawca 13</option>
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