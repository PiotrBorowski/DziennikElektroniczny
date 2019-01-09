import React, { Component } from "react";
import { NavLink, withRouter } from "react-router-dom";
import "../Styles/Index.css";
import TokenHelper from '../helpers/tokenHelper'
import {connect} from 'react-redux'
import { CheckUserToken } from "../Actions/userActions";

class Header extends Component {
    constructor(props){
        super(props);
        console.log(this.props)
        window.onload = () => {
            this.props.dispatch(CheckUserToken())          
        }
    }

    handleLogout = () => {
        TokenHelper.setTokenInHeader(false);
        TokenHelper.setTokenInLocalStorage(false);
        localStorage.removeItem('username');
        this.props.history.push('/');
        this.props.dispatch(CheckUserToken());
    };

    render(){
        

        const Student = (
            <React.Fragment>
                <li className="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Uczen
                </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" hraf="/">Action</a>
                    </div>
                </li>
            </React.Fragment>
        );

        const Teacher = (
            <React.Fragment>
                <li className="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Nauczyciel
                </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" href="/">Action</a>

                    </div>
                </li>
            </React.Fragment>
        )

        const Parent = (
            <React.Fragment>
              <li className="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Rodzic
                </a>
                  <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" href="/">Action</a>
                        <a class="dropdown-item" href="/">Another action</a>
                        <a class="dropdown-item" href="/">Something else here</a>
                    </div>
              </li>
            </React.Fragment>
        )

        const Admin = (
            <React.Fragment> 
              <li className="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Administrator
                </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" href="/Users">Lista Użytkowników</a>
                        <a class="dropdown-item" href="/Classes">Lista Klas</a>
                        <a class="dropdown-item" href="/AddUser">Dodaj Użytkownika</a>
                        <a class="dropdown-item" href="/AddClass">Dodaj Klasę</a>
                        <a class="dropdown-item" href="/AddStudent">Dodaj Ucznia</a>
                    </div>
              </li>
            </React.Fragment>
        )

        return (

    <nav className="navbar navbar-expand-sm navbar-dark bg-dark fixed-top">
        <div className="container">
        <NavLink className="navbar-brand" to="/">Dziennik Elektroniczny</NavLink>
        <div className="navbar-header">
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
          </button>
          </div>

          <div className="collapse navbar-collapse" id="navbarResponsive">
            <ul className="navbar-nav ml-auto">

            {Student}
            {Parent}
            {Teacher}
            {Admin}


            </ul>
          </div>   
        </div>
    </nav>
        )
    }
}

function mapStateToProps(state){
    return{
        user: state.user
    };
}

export default withRouter(connect(mapStateToProps)(Header));