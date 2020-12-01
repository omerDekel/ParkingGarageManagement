import React, { Component } from 'react';

export class GarageState extends Component {
  //static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { /*forecasts: [], loading: true */};
    }

    componentDidMount() {
        fetch('https://localhost:44354/api/garage/getgaragestate').then(res => res.json()).then(res => console.log(res));
    }

  render() {

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
      </div>
    );
  }


}
