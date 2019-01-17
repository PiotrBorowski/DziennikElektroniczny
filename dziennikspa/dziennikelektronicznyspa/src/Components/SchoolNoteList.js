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
            notes: []
        };

    }

    componentDidMount(){
            this.getGrades(BASE_URL + "/user/Uwagi?id=2");    
            console.log(this.state.notes);
    }   

    getGrades(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                notes: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }


    renderNotes = () => {
        
        const columns =[
            {Header: 'IdNauczyciela', accessor:'idNauczyciela'},
            {Header:'Uwaga', accessor:'tresc'}
    ]
        return ( <ReactTable data={this.state.notes} columns={columns}/>);
    }

    render(){
    

        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Uwagi ucznia:</h2>
                    <div>
                        {this.renderNotes()}
                    </div>
                </div>
            </div>        
        )
    }
}