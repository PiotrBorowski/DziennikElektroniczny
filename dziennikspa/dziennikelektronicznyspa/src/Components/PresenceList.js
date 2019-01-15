import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import User from "./User"
import "../Styles/Page.css"
import "../Styles/colors.css"

import ReactTable from "react-table"
import 'react-table/react-table.css'
import Moment from 'moment';

export default class UserList extends Component {
    constructor(props){
        super(props);
        this.state={
            presence: []
        };
    }

    componentDidMount(){
            this.getList(BASE_URL + "/user/Obecnosci?id=2");    
            console.log(this.state.units);
    }   

    getList(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                presence: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }


    renderUnits = () => {
        
        const columns =[
            {id:"data",Header: 'Data',  accessor: d => {
        Moment.locale('pl');
        var date = Moment(d.data);
        return date.format('d MMM');
      }
    },
            {Header:'Godzina', accessor: 'godzina'},
            {id:'czyObecny',Header:'Obecny/a', accessor: d => this.CzyObecny(d.czyObecny)}
    ]
        return ( <ReactTable data={this.state.presence} columns={columns}/>);
    }



    CzyObecny(czyobecny)
    {
        switch(czyobecny)
        {
            case true:
                return <span className="green">OBECNY</span>
            case false:
                return <span className="red">NIEOBECNY</span>
            default:
                return <span >-</span>
        }          
    }


    render(){
    

        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Obecności</h2>
                    <div>
                        {this.renderUnits()}
                    </div>
                </div>
            </div>        
        )
    }
}