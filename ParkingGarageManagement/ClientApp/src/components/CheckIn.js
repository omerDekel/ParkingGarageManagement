import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { baseUrl } from '../services/api';

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
            vehicleLength: ''

        };
    }
    myChangeHandler = (event) => {
        let nam = event.target.name;
        let val = event.target.value;
        this.setState({ [nam]: val });
    }
    checkValidation() {
        if (this.state.username == "") {
            alert("Please provide a name");
            return false;
        }
        if (this.state.licensePlateId == "") {
            alert("Please provide a license plate id");
            return false;
        }
        if (this.state.ticketType == "") {
            alert("Please provide a ticket type");
            return false;
        }
        if (this.state.vehicleType == "") {
            alert("Please provide a vehicle type");
            return false;
        }
        if (this.state.vehicleWidth == "") {
            alert("Please provide a vehicle width");
            return false;
        }
        if (this.state.vehicleLength == "") {
            alert("Please provide a vehicle length");
            return false;
        }
        if (this.state.vehicleHeight == "") {
            alert("Please provide a vehicle height");
            return false;
        }
        return true;
    }
    handleSubmit = () => {
        // check user input validation

        if (this.checkValidation()) {
            const url = baseUrl+'garage/checkin';

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
                .then(res => {
                    debugger
                    if (res.StatusCode == 400) {
                        alert(res.Value);
                    }else if (res.TicketTypeIsSuitable == true) {
                        alert("The lot for the vehicle is: " + res.Lot);
                    }
                    else if (res.TicketTypeIsSuitable == false) {
                        alert("The ticket type is not suitable with the vehicle, you may"
                            + " trade your ticket to: " + res.MatchingTicketRank + " you should add more " + res.DifferenceCost + "$");
                    }
                });

        }
        //alert('username: ' + this.state.username);

    }

    render() {

        return (
            <Form onSubmit={this.handleSubmit}>
                <FormGroup>
                    <h1>Hello</h1>
                    <Label>Name:</Label>
                    <Input
                        type='text'
                        name='username'
                        onChange={this.myChangeHandler}
                    />
                    <Label>License Plate ID:</Label>
                    <Input
                        type='text'
                        name='licensePlateId'
                        onChange={this.myChangeHandler}
                    />
                    <Label>Vehicle Type:</Label>
                    <Input
                        type='text'
                        name='vehicleType'
                        onChange={this.myChangeHandler}
                    />
                    <Label>Vehicle Height:</Label>
                    <Input
                        type='text'
                        name='vehicleHeight'
                        onChange={this.myChangeHandler}
                    />
                    <Label>Vehicle Width:</Label>
                    <Input
                        type='text'
                        name='vehicleWidth'
                        onChange={this.myChangeHandler}
                    />
                    <Label>Vehicle Length:</Label>
                    <Input
                        type='text'
                        name='vehicleLength'
                        onChange={this.myChangeHandler}
                    />
                    <Label >Phone</Label>
                    <Input
                        type="text"
                        name="phone"
                        onChange={this.myChangeHandler}
                    />
                    <label>
                        Ticket Type
                    <Input type="select" name="ticketType" onChange={this.myChangeHandler}>
                            <option value=""></option>
                            <option value="VIP">VIP</option>
                            <option value="Value">Value</option>
                            <option value="Regular">Regular</option>

                        </Input>

                    </label>
                </FormGroup>

                <Button color="primary" onClick={this.handleSubmit}>Submit</Button>
            </Form>
        );
    }
}
