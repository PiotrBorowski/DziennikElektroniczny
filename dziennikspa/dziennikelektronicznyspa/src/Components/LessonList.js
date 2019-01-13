import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import User from "./User"
import "../Styles/Page.css"
import ReactTable from "react-table"
import 'react-table/react-table.css'

export default class UserList extends Component {
    constructor(props){
        super(props);
        this.state={
            units: []
        };

    }

    componentDidMount(){
            this.getList(BASE_URL + "/user/PlanLekcji?id=2");    
            console.log(this.state.units);
    }   

    getList(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                units: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }


    renderUnits = () => {
        
        const columns =[
            {Header: 'Dzien Tygodnia', accessor:'dzienTygodnia'},
            {Header:'Godzina', accessor:'godzina'},
            {Header:'Przedmiot', accessor:'przedmiot'},
            {Header:'Sala', accessor:'sala'}

    ]
        return ( <ReactTable data={this.state.units} columns={columns}/>);
    }



    Role(roleId)
    {
        switch(roleId)
        {
            case 1:
                return <span >Admin</span>
            case 2:
                return <span >Nauczyciel</span>
            case 3:
                return <span >Rodzic</span>
            case 4:
                return <span >Uczen</span>
            default:
                return <span >Undefined</span>
        }          
    }


    render(){
    

        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Plan Lekcji</h2>
                    <div>
                        {this.renderUnits()}
                    </div>
                </div>
            </div>        
        )
    }
}