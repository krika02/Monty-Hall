import React, { Component } from 'react';
import MonthyHallPic from './monthy-hall-host.jpg';
import Calculator from '../calculator/Calculator';

export class Home extends Component {

    render() {
        return (
            <div>
                <h1>Welcome to the Monthy Hall simulator</h1>
                <img src={MonthyHallPic} alt="monthy hall" />
                <Calculator />
            </div>
        );
    }
}