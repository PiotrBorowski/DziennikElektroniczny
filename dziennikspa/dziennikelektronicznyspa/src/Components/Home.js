import React, { Component } from "react";
import "../Styles/Index.css";

export default class Home extends Component {
  render() {
    return (
      <div>
        <div className="bgimage">
          <div className="container-fluid">
            <div className="hero-text">
              <h1>Dziennik Elektroniczny</h1>
              <p>
               Dziennik elektroniczny do zarzadzania biednymi uczniami
              </p>
            </div>
          </div>
        </div>
        <div className="container home-text">
          <p>
         Piotr Borowski Bartosz Powęska
          </p>
        </div>
      </div>
      
    );
  }
}