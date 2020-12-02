import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';

export class CheckOut extends Component {

  constructor(props) {
    super(props);
      this.state = { licensePlateId: '' };
  }
    myChangeHandler = (event) => {
        let nam = event.target.name;
        let val = event.target.value;
        this.setState({ [nam]: val });
    }
    handleSubmit = () => {
        const url = 'https://localhost:44354/checkout/' + this.state.licensePlateId;

        // post body data 
        /*const user = {
            LicensePlateID: this.state.licensePlateId,
           
        };*/

        // request options
        const options = {
            method: 'POST',
            //body: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
            }
        }

        // send POST request
        fetch(url, options).then(res => {
            
            alert(res);
            
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
