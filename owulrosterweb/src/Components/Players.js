import React, { Component } from 'react';
import logo from '../public/Images/owul-logo.png';
import TeamsList from './Components/TeamsList';
import $ from 'jquery';
import './App.css';

class Players extends Component {
    constructor() {
        super();
        this.state = {
        }
    }

    componentWillMount() {
        console.log("app mounted");
    }

    render() {
        let playerList = '';
        if (this.state.playersLoaded) {
            playerList = this.state.players.map(player => {
                let playerAvatar = process.env.PUBLIC_URL + "/Images/" + (player.Avatar || "100px-Default.png");
                return (
                    <tr key={player.PlayerId}>
                        <td><img src={playerAvatar} alt={player.Avatar} className="PlayerAvatar" /></td>
                        <td>{player.Name}</td>
                        <td>{player.BNetTag}</td>
                        <td>{player.SkillRating}</td>
                        <td>{player.AverageKills}</td>
                        <td>{player.AverageDeaths}</td>
                        <td>{player.AverageAssists}</td>
                    </tr>
                );
            });
        }
        return (
            <section id="Players">
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
                            <th></th>
                            <th>Name</th>
                            <th>Battle.Net Tag</th>
                            <th>SkillRating</th>
                            <th>Skill Rating</th>
                            <th>Average Kills</th>
                            <th>Average Deaths</th>
                            <th>Average Assists</th>
                        </tr>
                        {players}
                    </tbody>
                </table>
            </section>
        );
    }
}

export default Players;
//"#FA9D18"
//"#181B1F"