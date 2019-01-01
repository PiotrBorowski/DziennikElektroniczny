import React, { Component } from "react";
import axios from "axios"
import {BASE_URL} from "../constants"
import User from "./User"
import "../Styles/Page.css"

export default class UserList extends Component {
    constructor(props){
        super(props);
        this.state={
            users: []
        };
    }

    componentDidMount(){

            this.getUsers(BASE_URL + "/admin/Users");    
            console.log(this.state.users);
    }   

    getUsers(url){
        return axios.get(url).then(response => {
            console.log(response);
            this.setState({
                users: response.data
            })
        }).catch((error) => {
            console.log(error);
        });
    }

    renderUsers = () => {
        return this.state.users.map(user => 
            <User onDelete={this.deleteUser} userId={user.idUzytkownika} name={user.imie} surName={user.nazwisko} phoneNumber={user.numerKontaktowy} roleId={user.idRoli} />
        );
    }

    deleteUser = id =>{
        return axios.delete(BASE_URL + "/admin/Users?userId=" + id)
        .then(this.setState({ pages: this.usersExceptSpecified(id)}))
        .then(() => this.props.history.push('/users'))
        .catch(err => {
            console.log(err);
        })
    }

    usersExceptSpecified = id =>{
        return this.state.users.filter(user => user.userId !== id)
    }

    render(){
        return (
            <div className="container">
                <div className="pages-group">
                    <h2 className="title">All users</h2>
                    <div>
                        {this.renderUsers()}
                    </div>
                </div>
            </div>        
        )
    }
}