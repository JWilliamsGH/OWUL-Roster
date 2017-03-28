import React, { Component } from 'react';

class TeamsListItem extends Component {
    constructor() {
        super();
        this.state = {
            team: {}
        }
    }

    GetTeamDetails(teamId)
    {
        this.props.GetTeamDetails(teamId);
    }

    render() {
        return (
            <li>
                <a href="#" onClick={this.GetTeamDetails.bind(this, this.props.team.TeamId)}>{this.props.team.Name}</a>
            </li>
        );
    }
}

export default TeamsListItem;