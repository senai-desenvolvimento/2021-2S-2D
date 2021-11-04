import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

import './index.css';

import Home from './pages/home/App';
import TiposEventos from './pages/tiposEventos/TiposEventos.jsx';
import NotFound from './pages/notFound/NotFound';
import Login from './pages/login/login';

import reportWebVitals from './reportWebVitals';
import { parseJwt, usuarioAutenticado } from './services/auth';

const PermissaoAdm = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && parseJwt().role === '1' ?
      // ... => operador spread ou de espelhamento
      <Component {...props} /> :
      <Redirect to="/login" />
    }
  />
)

const PermissaoComum = ({ component : Component }) => (
  <Route 
    render = { props => 
      usuarioAutenticado() && parseJwt().role === '2' ?
      // ... => operador spread ou de espelhamento
      <Component {...props} /> :
      <Redirect to="/login" />
    }
  />
)

const routing = (
  <Router>
    <div>
      <Switch>
        <PermissaoComum exact path="/" component={Home} />
        <PermissaoAdm path="/tiposeventos" component={TiposEventos} />
        <Route path="/login" component={Login} />
        <Route path="/notfound" component={NotFound} />
        {/* <Route path="/*" component={NotFound} /> Outra forma */}
        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
