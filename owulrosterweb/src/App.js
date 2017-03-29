import React, { Component } from 'react';
import logo from '../public/Images/owul-logo.png';
import TeamsList from './Components/TeamsList';
import TeamDetails from './Components/TeamDetails';
import AppHeader from './Components/AppHeader';
import $ from 'jquery';
import './App.css';

class App extends Component {
    constructor() {
        super();
        this.state = {
            teams: [],
            team: {},
            players: [],
            showTeamDetails: false,
            showPlayers: false,
            showAddTeam: false,
            showAddPlayer: false
        }
    }

    componentWillMount() {
        this.GetTeams();
    }

    ShowTeamDetails() {
        this.setState({
            showTeamDetails: true,
            showPlayers: false,
            showAddTeam: false,
            showAddPlayer: false
        })
    }

    GetTeams() {
        $.ajax({
            url: "http://localhost:9001/API/Teams",
            dataType: "json",
            cache: false,
            success: function (data) {
                console.log(data);
                this.setState({ teams: data.teams });
            }.bind(this),
            error: function (xhr, status, error) {
                console.log(error);
            }
        });
    }

    GetTeamDetails(teamId) {
        $.ajax({
            url: "http://localhost:9001/API/Teams/" + teamId,
            dataType: "json",
            cache: false,
            success: function (data) {
                this.setState({ showTeamDetails: true, team: data.team });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });

        $.ajax({
            url: "http://localhost:9001/API/Players/TeamId/" + teamId,
            dataType: "json",
            cache: false,
            success: function (data) {
                console.log(data);
                this.setState({ showPlayers: true, players: data.players });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    render() {
        let teamDetails = '';
        if (this.state.showTeamDetails) {
            teamDetails = (
                <TeamDetails Team={this.state.team}></TeamDetails>
            );
        }
        let playerList = '';
        if (this.state.showPlayers) {
            playerList = this.state.players.map(player => {

                //TODO: Refactor - This should look like teamDetails above and just have one component in it and then
                //the tr down below should be another component. That''s what should actually be in the .map function

                let playerAvatar = process.env.PUBLIC_URL + "/Images/" + (player.Avatar || "100px-Default.png");
                return (
                    <div key={player.PlayerId}>
                        <table id="PlayerList">
                            <tbody>
                                <colgroup>
                                    <col />
                                    <col style={{ width: '100px' }} />
                                    <col style={{ width: '100px' }} />
                                    <col style={{ width: '100px' }} />
                                    <col style={{ width: '100px' }} />
                                    <col style={{ width: '100px' }} />
                                    <col style={{ width: '100px' }} />
                                </colgroup>
                                <tr>
                                    <td><img src={playerAvatar} alt={player.Avatar} className="PlayerAvatar" /></td>
                                    <td>{player.Name}</td>
                                    <td>{player.BNetTag}</td>
                                    <td>{player.SkillRating}</td>
                                    <td>{player.AverageKills}</td>
                                    <td>{player.AverageDeaths}</td>
                                    <td>{player.AverageAssists}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                );
            });
        }
        return (
            <section className="App">
                <AppHeader Logo={logo}></AppHeader>
                <div id="Teams-List">
                    <TeamsList teams={this.state.teams} GetTeamDetails={this.GetTeamDetails.bind(this)}></TeamsList>
                </div>
                <div id="Content">
                    <div className="TeamDetails">
                        {teamDetails}
                    </div>
                    <div className="PlayerList">
                        {playerList}
                    </div>
                </div>
            </section>
        );
    }
}

export default App;
//"#FA9D18"
//"#181B1F"


//<tr>
//    <th></th>
//    <th>Name</th>
//    <th>Battle.Net Tag</th>
//    <th>SkillRating</th>
//    <th>Skill Rating</th>
//    <th>Average Kills</th>
//    <th>Average Deaths</th>
//    <th>Average Assists</th>
//</tr>


//let teamDetails = '';
//if (this.state.teamSelected) {
//    let avatar = process.env.PUBLIC_URL + "/Images/" + (this.state.team.Avatar || "100px-Default.png");
//    teamDetails = (
//        <span>
//            <img src={avatar} alt={this.state.team.Avatar} className="TeamAvatar" />
//            <span className="TeamName">{this.state.team.Name}</span>
//            <span className="TeamStats">
//                <table>
//                    <tbody>
//                        <tr>
//                            <th>Score</th>
//                            <th>Wins</th>
//                            <th>Losses</th>
//                            <th>Ties</th>
//                        </tr>
//                        <tr>
//                            <td>{this.state.team.Score}</td>
//                            <td>{this.state.team.Wins}</td>
//                            <td>{this.state.team.Losses}</td>
//                            <td>{this.state.team.Ties}</td>
//                        </tr>
//                    </tbody>
//                </table>
//            </span>
//        </span>
//    );
//}