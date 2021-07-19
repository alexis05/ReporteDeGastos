import React, { Component } from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'
import Report from './components/Report'

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={Report} />

        </Switch>
      </BrowserRouter>
    )
  }
}

export default App