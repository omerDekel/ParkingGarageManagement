import React, { Component } from 'react';

export class CheckOut extends Component {

  constructor(props) {
    super(props);
    this.state = {  };
    //this.incrementCounter = this.incrementCounter.bind(this);
  }

  

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p aria-live="polite">Current count: <strong></strong></p>

      </div>
    );
  }
}
