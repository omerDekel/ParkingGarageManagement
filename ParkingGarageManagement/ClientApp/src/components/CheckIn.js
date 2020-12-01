import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';

export class CheckIn extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            phone: '',
            licensePlateId: '',
            ticketType: '',
            vehicleType: '',
            vehicleHeight: '',
            vehicleWidth: '',
            vehicleLength:''

        };
    }
    myChangeHandler = (event) => {
        let nam = event.target.name;
        let val = event.target.value;
        this.setState({ [nam]: val });
    }
    handleSubmit = () => {
        //alert('username: ' + this.state.username);
        const url = 'https://localhost:44354/checkin';

        // post body data 
        const user = {
            Name: this.state.username,
            LicensePlateID: this.state.licensePlateId,
            Phone: this.state.phone,
            TicketType: this.state.ticketType,
            VehicleType: this.state.vehicleType,
            Height: this.state.vehicleHeight,
            Width: this.state.vehicleWidth,
            Length: this.state.vehicleLength
        };

        // request options
        const options = {
            method: 'POST',
            body: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
            }
        }

        // send POST request
        fetch(url, options)
            .then(res => res.json())
            .then(res => console.log(res));

    }

    render() {

        return (
            <Form onSubmit={this.handleSubmit}>
                <h1>Hello</h1>
                <p>Name:</p>
                <input
                    type='text'
                    name='username'
                    onChange={this.myChangeHandler}
                />
                <p>License Plate ID:</p>
                <input
                    type='text'
                    name='licensePlateId'
                    onChange={this.myChangeHandler}
                />
                <p>Vehicle Type:</p>
                <input
                    type='text'
                    name='vehicleType'
                    onChange={this.myChangeHandler}
                />
                <p>Vehicle Height:</p>
                <input
                    type='text'
                    name='vehicleHeight'
                    onChange={this.myChangeHandler}
                />
                <p>Vehicle Width:</p>
                <input
                    type='text'
                    name='vehicleWidth'
                    onChange={this.myChangeHandler}
                />
                <p>Vehicle Length:</p>
                <input
                    type='text'
                    name='vehicleLength'
                    onChange={this.myChangeHandler}
                />
                <FormGroup>
                    <Label for="Phone">Phone</Label>
                    <Input type="email" name="email" id="phone" placeholder="insert your phone" />
                </FormGroup>
                <label>
                    Ticket Type
          <select value={this.state.vehicleType} onChange={this.myChangeHandler}>
                        <option value="vip">VIP</option>
                        <option value="value">Value</option>
                        <option value="regular">Regular</option>
                    </select>
                </label>

                <input type="button" value="Submit" onClick={this.handleSubmit} />
            </Form>
        );
  }
}
