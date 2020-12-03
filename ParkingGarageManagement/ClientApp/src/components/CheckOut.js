import React, { Component } from 'react';
import { Button, Form, Label, Input } from 'reactstrap';
import { baseUrl } from '../services/api';

export class CheckOut extends Component {

  constructor(props) {
    super(props);
      this.state = { licensePlateId: '' };
    }
    //changing input handler function
    myChangeHandler = (event) => {
        let nam = event.target.name;
        let val = event.target.value;
        this.setState({ [nam]: val });
    }
    // handle submit function
    handleSubmit = () => {
        const url = baseUrl+'garage/checkout/';

        // post body data 
        const checkoutInput = {
            LicensePlateID: this.state.licensePlateId,
           
        };

        // request options
        const options = {
            method: 'POST',
            body: JSON.stringify(checkoutInput),
            headers: {
                'Content-Type': 'application/json'
            }
        }

        // send POST request
        fetch(url, options).then(res => res.json()).then(res => {           
            if (res === true) {
                alert("Thank you.Goodbye!")
            } else {
                alert("Check out failed.")
            }
        });
    };
  

  render() {
    return (
        <Form onSubmit={this.handleSubmit}>
            <Label>License Plate ID:</Label>
            <Input
                type='text'
                name='licensePlateId'
                onChange={this.myChangeHandler}
            />
            <Button color="primary" onClick={this.handleSubmit}>Submit</Button>
      </Form>
    );
  }
}
