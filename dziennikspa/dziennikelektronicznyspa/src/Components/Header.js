import React, { Component } from "react";
import { NavLink, withRouter } from "react-router-dom";
import "../Styles/Index.css";
import {connect} from 'react-redux'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export default class Header extends Component {
    constructor(props){
        super(props);
        console.log(this.props)
    }


    render(){
        

        const Student = (
            <React.Fragment>
                <li className="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Uczen
                </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" href="/Messages">Wiadomości</a>
                        <a class="dropdown-item" href="/SchoolNoteList">Uwagi</a>
                        <a class="dropdown-item" href="/PresenceList">Obecności</a>
                        <a class="dropdown-item" href="/Grades">Oceny</a>
                        <a class="dropdown-item" href="/LessonList">Plan Lekcji</a>

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
                        <a class="dropdown-item" href="/AddGrade">Dodaj Ocene</a>
                        <a class="dropdown-item" href="/ExcuseList">Usprawiedliwienia</a>
                        <a class="dropdown-item" href="/AddSchoolNote">Dodaj Uwage</a>
                        <a class="dropdown-item" href="/AddLesson">Dodaj Lekcję</a>
                        <a class="dropdown-item" href="/AddPresenceList">Sprawdź Obecność</a>
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
                        <a class="dropdown-item" href="/AddExcuseForm">Usprawieliwienie</a>
                        <a class="dropdown-item" href="/">Oceny dzieci</a>
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
                        <a class="dropdown-item" href="/AddUser">Dodaj Użytkownika</a>
                        <a class="dropdown-item" href="/AddStudent">Dodaj Ucznia</a>                       
                        <a class="dropdown-item" href="/Classes">Lista Klas</a>
                        <a class="dropdown-item" href="/AddClass">Dodaj Klasę</a>
                        <a class="dropdown-item" href="/AddSubject">Stwórz Przedmiot</a>
                        <a class="dropdown-item" href="/AddSubjectUnit">Dodaj Jednostkę Lekcyjną</a>

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
            <li className="nav-item dropdown">
            <NavLink className="nav-link" to="/Messages"><i class="fas fa-envelope"></i></NavLink>
            </li>

            <li>
            <NavLink className="nav-link" to="/SendMessage"><i class="fa fa-paper-plane" aria-hidden="true"></i></NavLink>
            </li>

            </ul>
          </div>   
        </div>
    </nav>
        )
    }
}
