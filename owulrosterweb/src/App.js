import React, { Component } from 'react';
import logo from '../public/Images/owul-logo.png';
import TeamsList from './Components/TeamsList';
import $ from 'jquery';
import './App.css';

class App extends Component {
    constructor() {
        super();
        this.state = {
            teams: []
        }
    }

    componentWillMount() {
        console.log("app mounted");
        this.GetTeams();
    }

    GetTeams() {
        $.ajax({
            url: "http://localhost:9001/Teams",
            dataType: "json",
            cache: false,
            success: function (data) {
                this.setState({ teams: data.teams });
            }.bind(this),
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }

    render() {
        return (
            <section className="App">
                <div className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <h2>OWUL Div 14 Roster</h2>
                </div>
                <ul id="Teams-List">
                    <TeamsList teams={this.state.teams}></TeamsList>
                </ul>
            </section>
        );
    }
}

export default App;
//"#FA9D18"
//"#181B1F"