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
            users: []
        };

    }

    componentDidMount(){
            this.getUsers(BASE_URL + "/admin/Uzytkownicy");    
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
        
        const columns =[
            {Header: 'Imie', accessor:'imie'},
            {Header:'Nazwisko', accessor:'nazwisko'},
            {Header:'Numer', accessor:'numerKontaktowy'},
            {id:'rola',Header:'Rola', accessor: d => this.Role(d.idRoli)}
    ]
        return ( <ReactTable data={this.state.users} columns={columns}/>);
    }

    deleteUser = id =>{
        return axios.delete(BASE_URL + "/admin/Uzytkownicy?userId=" + id)
        .then(this.setState({ pages: this.usersExceptSpecified(id)}))
        .then(() => this.props.history.push('/users'))
        .catch(err => {
            console.log(err);
        })
    }

    usersExceptSpecified = id =>{
        return this.state.users.filter(user => user.userId !== id)
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
                    <h2 className="title">Wszyscy użytkownicy</h2>
                    <div>
                        {this.renderUsers()}
                    </div>
                </div>
            </div>        
        )
    }
}