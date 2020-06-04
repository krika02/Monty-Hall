import React, { Component } from 'react';
import './Calculator.css';

export default class InputFields extends Component {

    constructor(props) {
        super(props);
        this.state = {
            door: 1,
            changeDoor: 1,
            iteration: 100000,
            loading: false,
            message: 'Please input, door number, if you would like to change door and number of iterations'
        };

        this.doorChanged = this.doorChanged.bind(this);
        this.changeDoorChanged = this.changeDoorChanged.bind(this);
        this.iterationChanged = this.iterationChanged.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    doorChanged(event) {
        this.setState({ door: parseInt(event.target.value) });
    }

    changeDoorChanged(event) {
        this.setState({ changeDoor: parseInt(event.target.value) });
    }

    iterationChanged(event) {
        this.setState({ iteration: parseInt(event.target.value) });
    }

    async handleSubmit(event) {
        event.preventDefault();

        this.setState({ loading: true });

        const response = await fetch('monthyHall/calculate', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            }
            ,
            body: JSON.stringify({
                door: this.state.door,
                changeDoor: this.state.changeDoor,
                iterations: this.state.iteration
            })
        });

        const data = await response.json();
        this.setState({
            loading: false,
            message: 'After ' + this.state.iteration + ' numbers of iterations there is a ' + data + '% chance that you would pick the right door.'
        });
    }

    render() {
        return (
            <form className="input-fields" onSubmit={this.handleSubmit}>
                <p>{this.state.message}</p>
                <div className="row">
                    <div className="col-sm">
                        <label>Door number (1-3)</label>
                        <input className="form-control" type="number" min="1" max="3" value={this.state.door} onChange={this.doorChanged} />
                    </div>
                    <div className="col-sm">
                        <label>Change door? (yes/no)</label>
                        <select className="form-control" value={this.state.changeDoor} onChange={this.changeDoorChanged} >
                            <option value="1">Yes</option>
                            <option value="2">No</option>
                        </select>
                    </div>
                    <div className="col-sm">
                        <label>Iterations (1-100000)</label>
                        <input className="form-control" name="iterations" type="number" min="1" max="100000" value={this.state.iteration} onChange={this.iterationChanged} />
                    </div>
                </div>
                <div className="row">
                    <div className="col">
                        <input className="btn btn-primary submit" type="submit" value="Calculate" disabled={this.state.loading}  />
                    </div>
                </div>
            </form>
        );
    }
}
