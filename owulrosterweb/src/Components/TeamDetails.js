import React, { Component } from 'react';

class TeamDetails extends Component {
    constructor() {
        super();
        this.state = {
            team: {}
        }
    }

    componentWillMount() {
        this.setState({ team: this.props.Team });
    }

    render() {
        let avatar = process.env.PUBLIC_URL + "/Images/" + (this.state.team.Avatar || "100px-Default.png");

        return (
            <section id="Team-Details" className="TeamDetails">
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
            </section>
        );
    }
}

export default TeamDetails;