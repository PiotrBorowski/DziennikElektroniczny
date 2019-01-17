import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import Class from "./Class"
import "../Styles/Page.css"
import Excuse from "./Excuse";

export default class UserList extends Component {
    constructor(props){
        super(props);
        this.state={
            excuses: []
        };
    }

    componentDidMount(){

            this.getUsers(BASE_URL + "/teacher/Usprawiedliwienia?parentId=3");    
            console.log(this.state.excuses);
    }   

    getUsers(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                excuses: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }

    renderExcuses = () => {
        return this.state.excuses.map(x => 
            <Excuse  id={x.idUsprawiedliwienie} text={x.tresc} date={x.data} accepted={x.czyZatwierdzone}  />
        );
    }


    render(){
        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Usprawiedliwienia</h2>
                    <div>
                        {this.renderExcuses()}
                    </div>
                </div>
            </div>        
        )
    }
}