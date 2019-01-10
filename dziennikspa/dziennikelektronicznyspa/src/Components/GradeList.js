import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import "../Styles/Page.css"
import ReactTable from "react-table"
import 'react-table/react-table.css'

export default class GradeList extends Component {
    constructor(props){
        super(props);
        this.state={
            grades: []
        };

    }

    componentDidMount(){
            this.getGrades(BASE_URL + "/user/Oceny?id=2");    
            console.log(this.state.grades);
    }   

    getGrades(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                grades: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }


    renderGrades = () => {
        
        const columns =[
            {Header: 'Przedmiot', accessor:'wartosc'},
            {Header:'Ocena', accessor:'przedmiot'},
            {id:'Kategoria',Header:'Kategoria', accessor: d => this.GradeCategory(d.kategoriaOceny)}
    ]
        return ( <ReactTable data={this.state.grades} columns={columns}/>);
    }

    GradeCategory(id)
    {
        switch(id)
        {
            case 1:
                return <span >Koncowa</span>
            case 2:
                return <span >Proponowana</span>
            case 3:
                return <span >Klasówka</span>
            case 5:
                return <span >Test</span>
            case 6:
                return <span >Kartkówka</span>
            case 7:
                return <span >Odpowiedź Ustna</span>
            default:
                return <span >Undefined</span>
        }          
    }


    render(){
    

        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Oceny ucznia:</h2>
                    <div>
                        {this.renderGrades()}
                    </div>
                </div>
            </div>        
        )
    }
}