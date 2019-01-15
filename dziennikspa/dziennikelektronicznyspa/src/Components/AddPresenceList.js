import React, { Component } from "react";
import {BASE_URL} from "../constants"
import "../Styles/Form.css"
import axios from "axios"
import {Input} from 'reactstrap'
import Presence from "./Presence";

export default class AddPresenceList extends Component{
    constructor(props){
        super(props);

        this.state =
        {
            students: [],
            lessonId: 0,
            accepted: false
        };
    }

    componentDidMount(){

    } 

    getStudents(url){
        return axios.get(url).then(response => {
          console.log(response);
          this.setState({
              students: response.data
           })
        }).catch((error) => {
           console.log(error);
        });
    }

    handleUserInputLesson = e => {
        this.setState({ lessonId: e.target.value });
    }


    handleSubmit = e => {
        e.preventDefault();
        console.log(this.state);
        this.getStudents(BASE_URL + "/teacher/obecnoscUczniowie?lessonId="+ this.state.lessonId);         
        this.setState({ accepted: true});
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

    renderStudents = () => {
        return this.state.students.map(x => 
            <Presence name={x.imie} surname={x.nazwisko} studentId={x.idUzytkownika} lessonId = {this.state.lessonId} />
        );
    }

    render(){
        return (
        <div className="form-center">
        <form onSubmit={this.handleSubmit}>
            <h2 className="title">Sprawdz obecnosc</h2>
            <div className="form-group col-md-10 offset-md-1">       
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <label class="input-group-text" for="inputGroupSelect01">Lekcja</label>
                    </div>
                    <Input type="select" class="custom-select" id="inputGroupSelect01" onChange={this.handleUserInputLesson}>
                        <option selected value=''></option>
                        <option value="1">Lekcja 1</option>
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

            {this.state.accepted ? this.renderStudents() : null }

        </div>
        )
    }
}