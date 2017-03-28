import React, { Component } from 'react';
import TeamsListItem from './TeamsListItem';

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

    GetTeamDetails(teamId) {
        this.props.GetTeamDetails(teamId);
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
        return (
            <section id="Teams-List">
                <div className="TeamsList">
                    <h1>Div 14 Teams</h1>
                    <ul>
                        {teamsList}
                    </ul>
                </div>
            </section>
        );
    }
}

export default TeamsList;