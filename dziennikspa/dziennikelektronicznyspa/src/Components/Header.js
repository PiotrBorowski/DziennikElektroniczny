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
                <li className="nav-item">
                    <NavLink className="nav-link" to="/student">Uczen</NavLink>
                </li>
            </React.Fragment>
        );

        const Teacher = (
            <React.Fragment>
                <li className="nav-item">
                    <NavLink className="nav-link" to="/teacher">Nauczyciel</NavLink>
                </li>
            </React.Fragment>
        )

        const Parent = (
            <React.Fragment>
              <li className="nav-item">
                  <NavLink className="nav-link" to="/parent">Rodzic</NavLink>
              </li>
            </React.Fragment>
        )

        const Admin = (
            <React.Fragment> 
              <li className="nav-item">
                  <NavLink className="nav-link" to="/admin">Admin</NavLink>
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

              <li className="nav-item">
                <NavLink className="nav-link active" to="/">Home<span className="sr-only">(current)</span></NavLink>
              </li>

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