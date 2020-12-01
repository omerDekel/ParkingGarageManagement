import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { GarageState } from './components/GarageState';
import { CheckOut } from './components/CheckOut';

import './custom.css'
import { CheckIn } from './components/CheckIn';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>

            <Route exact path='/' component={CheckIn} />
            <Route path='/checkout' component={CheckOut} />
            <Route path='/garagestate' component={GarageState} />
      </Layout>
    );
  }
}
