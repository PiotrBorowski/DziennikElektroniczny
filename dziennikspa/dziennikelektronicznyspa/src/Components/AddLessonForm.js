import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddLessonForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            topic: "",
            date: "",
            teacherId: 0,
            subjectUnitId: 0         
        };
    }


    handleUserInputTopic = e => {
        this.setState({ topic: e.target.value });
    }

    handleUserInputDate = e =>{
        this.setState({date: e.target.value});
    }

    handleUserInputTeacherId = e =>{
        this.setState({teacherId: e.target.value});
    }

    handleUserInputSubjectUnitId = e =>{
        this.setState({subjectUnitId: e.target.value});
    }

    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/teacher/dodajLekcje", {
            Temat: this.state.topic,
            Data: this.state.date,
            IdProwadzacegoLekcje: this.state.teacherId,
            IdJednostkiLekcyjnej: this.state.subjectUnitId
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
            <h2 className="title">Dodaj nową lekcję</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Temat</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="topic"
                        ref="topic"
                        value={this.state.topic}
                        onChange={this.handleUserInputTopic}
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
                        <label class="input-group-text" for="inputGroupSelect01">Nauczyciel prowadzący</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputTeacherId}>
                        <option value=''></option>
                        <option value="6">Nauczyciel 6</option>
                        <option  value="13">Nauczyciel 13</option>
                    </Input>
                </div>         
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">JednostkaLekcyjna</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputSubjectUnitId}>
                        <option selected value=''></option>
                        <option value="1">Matematyka pon 11:15</option>
                        <option value="4">Matematyka pon 16:15</option>
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