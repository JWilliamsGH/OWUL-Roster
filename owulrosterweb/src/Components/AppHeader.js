import React, { Component } from 'react';

class AppHeader extends Component {
    constructor() {
        super();
        this.state = {
            logo: {}
        }
    }

    componentWillMount() {
        this.setState({ logo: this.props.Logo });
    }

    render() {
        return (
            <section className="App-header">
                <img src={this.state.logo} className="App-logo" alt="logo" />
                <h2>OWUL Div 14 Roster</h2>
            </section>
        );
    }
}

export default AppHeader;