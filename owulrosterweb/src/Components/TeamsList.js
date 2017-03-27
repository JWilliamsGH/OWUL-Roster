import React, { Component } from 'react';
import TeamsListItem from './TeamsListItem';
import $ from 'jquery';

class TeamsList extends Component {
    constructor() {
        super();
        this.state = {
            teamSelected: false,
            team: '',
            playersLoaded: false,
            players: ''
        }
    }

    componentWillMount() {
        console.log("TeamsList mounted");
    }

    GetTeamDetails(teamId) {
        $.ajax({
            url: "http://localhost:9001/Teams/" + teamId,
            dataType: "json",
            cache: false,
            success: function (data) {
                this.setState({ teamSelected: true, team: data.team });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });

        $.ajax({
            url: "http://localhost:9001/Players/" + teamId,
            dataType: "json",
            cache: false,
            success: function (data) {
                console.log(data.players);
                this.setState({ playersLoaded: true, players: data.players });
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err);
            }
        });
    }

    render() {
        let teamsList;
        if (this.props.teams) {
            teamsList = this.props.teams.map(teamItem => {
                return (
                    <TeamsListItem key={teamItem.TeamId} team={teamItem} GetTeamDetails={this.GetTeamDetails.bind(this)}></TeamsListItem>
                );
            });
        }
        let teamDetails = '';
        if (this.state.teamSelected) {
            let avatar = process.env.PUBLIC_URL + "/Images/" + (this.state.team.Avatar || "100px-Default.png");
            teamDetails = (
                <div>
                    <span>
                        <img src={avatar} alt={this.state.team.Avatar} className="TeamAvatar" />
                        <span className="TeamName">{this.state.team.Name}</span>
                        <span className="TeamStats">
                            <table>
                                <tbody>
                                    <tr>
                                        <th>Score</th>
                                        <th>Wins</th>
                                        <th>Losses</th>
                                        <th>Ties</th>
                                    </tr>
                                    <tr>
                                        <td>{this.state.team.Score}</td>
                                        <td>{this.state.team.Wins}</td>
                                        <td>{this.state.team.Losses}</td>
                                        <td>{this.state.team.Ties}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </span>
                    </span>
                </div>
            );
        }
        let playerList = '';
        if (this.state.playersLoaded) {
            playerList = this.state.players.map(player => {
                let playerAvatar = process.env.PUBLIC_URL + "/Images/" + (player.Avatar || "100px-Default.png");
                return (
                    <div key={player.PlayerId}>
                        <table>
                            <tbody>
                                <tr>
                                    <th></th>
                                    <th>Name</th>
                                    <th>Battle.Net Tag</th>
                                    <th>SkillRating</th>
                                    <th>Skill Rating</th>
                                    <th>Average Kills</th>
                                    <th>Average Deaths</th>
                                    <th>Average Assists</th>
                                </tr>
                                <tr>
                                    <td><img src={playerAvatar} alt={player.Avatar} className="PlayerAvatar" /></td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                    <td>{player.Score}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                );
            });
        }
        return (
            <section id="Teams-List">
                <div className="TeamsList">
                    <h1>Div 14 Teams</h1>
                    {teamsList}
                </div>
                <div className="TeamDetails">
                    {teamDetails}
                </div>
                <div>
                    {playerList}
                </div>
            </section>
        );
    }
}

export default TeamsList;