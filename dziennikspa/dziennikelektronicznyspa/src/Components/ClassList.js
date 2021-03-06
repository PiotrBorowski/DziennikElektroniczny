import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import Class from "./Class"
import "../Styles/Page.css"

export default class UserList extends Component {
    constructor(props){
        super(props);
        this.state={
            classes: []
        };
    }

    componentDidMount(){

            this.getUsers(BASE_URL + "/admin/Klasy");    
            console.log(this.state.classes);
    }   

    getUsers(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                classes: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }

    renderClasses = () => {
        return this.state.classes.map(x => 
            <Class classId={x.idKlasy} name={x.nazwa} year={x.rokSzkolny} teacherId={x.idWychowawcy}  />
        );
    }


    render(){
        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">Wszystkie klasy</h2>
                    <div>
                        {this.renderClasses()}
                    </div>
                </div>
            </div>        
        )
    }
}