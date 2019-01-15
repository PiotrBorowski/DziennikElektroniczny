import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'

export default class AddSubjectUnitForm extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            weekday: "",
            hour: 0,
            room: "",
            subjectId: 0,
            lessonPlanId: 0
        };
    }

    handleUserInputWeekDay = e =>{
        this.setState({weekday: e.target.value});
    }

    handleUserInputHour = e =>{
        this.setState({hour: e.target.value});
    }
    handleUserInputRoom = e =>{
        this.setState({room: e.target.value});
    }
    handleUserInputSubjectId = e =>{
        this.setState({subjectId: e.target.value});
    }
    handleUserInputLessonPlanId = e =>{
        this.setState({lessonPlanId: e.target.value});
    }


    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.sendRequest();
    }

    sendRequest = () => {
        axios.post(BASE_URL + "/admin/dodajJednostkeLekcyjna", {
            DzienTygodnia: this.state.weekday,
            Godzina: this.state.hour,
            Sala: this.state.room,
            IdPrzedmiotu: this.state.subjectId,
            IdPlanuLekcji: this.state.lessonPlanId
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
            <h2 className="title">Dodaj nową Jednostkę lekcyjną</h2>
            <div className="form-group col-md-10 offset-md-1">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Dzien tygodnia</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="weekday"
                        ref="weekday"
                        value={this.state.weekday}
                        onChange={this.handleUserInputWeekDay}
                        required
                        />
                </div>


            <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Godzina</span>
                    </div>
                    <input
                        className="form-control"
                        type="time"
                        name="hour"
                        ref="hour"
                        value={this.state.hour}
                        onChange={this.handleUserInputHour}
                        required
                        />
                </div>

            <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default">Sala</span>
                    </div>
                    <input
                        className="form-control"
                        type="text"
                        name="room"
                        ref="room"
                        value={this.state.room}
                        onChange={this.handleUserInputRoom}
                        required
                        />
                </div>


            
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Przedmiot</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputSubjectId}>
                        <option value=''></option>
                        <option value="1">Przedmiot 1</option>
                        <option  value="2">Przedmiot 2</option>
                    </Input>
                </div>       

                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Plan Lekcji</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputLessonPlanId}>
                        <option value=''></option>
                        <option value="1">Plan Lekcji 1</option>
                        <option  value="2">Plan Lekcji 2</option>
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