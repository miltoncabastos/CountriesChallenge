import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom'

import Header from './components/header'

import Card from '../src/pages/card'
import CardDetail from '../src/pages/card-detail'

export default function App() {
  return (
    <Router>
      <Header/>
      <Switch>
        <Route path="/" exact component={Card} /> 
        <Route path="/cardDetail/:numericCode" component={CardDetail} /> 
      </Switch>
    </Router>
  )
}
