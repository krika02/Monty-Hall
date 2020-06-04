import React, { Component } from 'react';
import MontyHallPic from './monty-hall-host.jpg';
import Calculator from '../calculator/Calculator';

export class Home extends Component {

    render() {
        return (
            <div>
                <h1>Welcome to the Monty Hall simulator</h1>
                <img src={MontyHallPic} alt="monty hall" />
                <Calculator />
            </div>
        );
    }
}