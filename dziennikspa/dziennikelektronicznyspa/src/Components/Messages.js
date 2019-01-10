import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import User from "./User"
import "../Styles/Page.css"
import ReactTable from "react-table"
import 'react-table/react-table.css'

export default class GradeList extends Component {
    constructor(props){
        super(props);
        this.state={
            messagesSend: [],
            messagesReceived: []
        };

    }

    componentDidMount(){
            this.getMessagesSend(BASE_URL + "/user/WiadomosciWyslane?id=6"); 
            this.getMessagesReceived(BASE_URL + "/user/WiadomosciOdebrane?id=6");    

            console.log(this.state.grades);
    }   

    getMessagesSend(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                messagesSend: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }

    getMessagesReceived(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                messagesReceived: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }


    renderMessagesSend = () => {
        
        const columns =[
            {Header: 'Odbiorca', accessor:'idOdbiorcy'},
            {Header:'Treść', accessor:'tresc'}
            
    ]
        return ( <ReactTable data={this.state.messagesSend} columns={columns}/>);
    }

    renderMessagesReceived = () => {
        
        const columns =[
            {Header: 'Nadawca', accessor:'idNadawcy'},
            {Header:'Treść', accessor:'tresc'}
    ]
        return ( <ReactTable data={this.state.messagesReceived} columns={columns}/>);
    }  

    render(){
    

        return (
            <div className="container">
                <div className="pages-group">
                    <h3 className="title">Wiadomości odebrane:</h3>
                    <div>
                        {this.renderMessagesReceived()}
                    </div>
                    <h3 className="title">Wiadomości wysłane:</h3>
                    <div>
                        {this.renderMessagesSend()}
                    </div>
                </div>
            </div>        
        )
    }
}