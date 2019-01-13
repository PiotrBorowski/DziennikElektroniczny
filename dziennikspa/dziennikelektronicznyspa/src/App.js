import React, { Component } from 'react';
import { Switch} from 'react-router-dom'
import Header from "./Components/Header";
import Home from './Components/Home';
import Footer from './Components/Footer'
import Unauthorized from './Components/Unauthorized'
import {
  BrowserRouter as Router,
  Route
} from 'react-router-dom';
import "./Styles/Index.css";
import NotFound from "./Components/NotFound"
import { library } from '@fortawesome/fontawesome-svg-core'
import { faStroopwafel, faTrash, faPlay } from '@fortawesome/free-solid-svg-icons'
import AddUzytkownikForm from './Components/AddUzytkownikForm';
import UserList from './Components/UserList';
import ClassList from './Components/ClassList';
import AddKlasaForm from './Components/AddKlasaForm';
import AddUczenForm from './Components/AddUczenForm';
import AddSubjectForm from './Components/AddSubject';
import AddSubjectUnitForm from './Components/AddSubjectUnit.Form';
import GradeList from './Components/GradeList';
import Messages from './Components/Messages';
import SendMessageForm from './Components/SendMessageForm';
import LessonList from './Components/LessonList';
import AddGradeForm from './Components/AddGradeForm';
import AddLessonForm from './Components/AddLessonForm';
import AddSchoolNoteForm from './Components/AddSchoolNoteForm';
import AddPresenceList from './Components/AddPresenceList';

library.add(faStroopwafel)
library.add(faTrash)
library.add(faPlay)

class App extends Component {
  render() {
    return (
      <Router>
         <div className="app">
          <Header />
          <Switch>
            <Route exact path="/" component={Home} />           
            <Route path="/unauthorized" component={Unauthorized}/>
            <Route path="/AddUser" component={AddUzytkownikForm}/>
            <Route path="/Users" component={UserList}/>
            <Route path="/AddClass" component={AddKlasaForm}/>
            <Route path="/AddStudent" component={AddUczenForm}/>
            <Route path="/Classes" component={ClassList}/>
            <Route path="/AddSubject" component={AddSubjectForm}/>
            <Route path="/AddSubjectUnit" component={AddSubjectUnitForm}/>
            <Route path="/Grades" component={GradeList}/>
            <Route path="/Messages" component={Messages}/>
            <Route path="/SendMessage" component={SendMessageForm}/>
            <Route path="/LessonList" component={LessonList}/>
            <Route path="/AddGrade" component={AddGradeForm}/>
            <Route path="/AddLesson" component={AddLessonForm}/>
            <Route path="/AddSchoolNote" component={AddSchoolNoteForm}/>
            <Route path="/AddPresenceList" component={AddPresenceList}/>
            <Route path="*" component={NotFound} />
          </Switch>
          <Footer/>
        </div>
      </Router>
    );
  }
}

export default App;
