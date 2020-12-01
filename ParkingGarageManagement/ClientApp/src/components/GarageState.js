import React, { Component } from 'react';
import './StyleSheet.css';

export class GarageState extends Component {
  //static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { garage: []};
    }

    componentDidMount() {
        fetch('https://localhost:44354/getgaragestate')
            .then(res =>  res.json() )
            .then(res => this.setState({ garage: res }) );
    }

    render() {
        const garage = this.state.garage.map((lot,index) => {
            if (lot.LicensePlate !== "") {
                return (<div key={index} className="lot occupiedLot">
                    <div>{lot.LotNumber}</div>
                    <div>{lot.LicensePlate}</div>
                </div>)
            } else {
                return (<div key={index} className="lot freeLot">
                    <div>{lot.LotNumber}</div>
                        </div>)
            }
        })

        return (
            <div className="lotContainer">
            {garage}
      </div>
    );
  }


}
