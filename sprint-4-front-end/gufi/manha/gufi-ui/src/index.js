import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/login';
import TiposEventos from './pages/tiposEventos/TiposEventos.jsx';
import Eventos from './pages/eventos/eventos';
import TiposUsuarios from './pages/tiposUsuarios/tiposUsuarios';
import Perfil from './pages/perfil/perfil';
import NotFound from './pages/notFound/NotFound';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

// const PermissaoComum = ({ component: Component }) => (
//   <Route
//     render={(props) =>
//       usuarioAutenticado() && parseJwt().role === '2' ? (
//         // operador spread
//         <Component {...props} />
//       ) : (
//         <Redirect to="login" />
//       )
//     }
//   />
// );

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} /> {/* Home */}
        <PermissaoAdm path="/tiposEventos" component={TiposEventos} /> {/* Tipos Eventos */}
        <PermissaoAdm path="/tiposUsuarios" component={TiposUsuarios} /> {/* Tipos Usuários */}
        <Route path="/login" component={Login} /> {/* Login */}
        <Route path="/eventos" component={Eventos} /> {/* Eventos */}
        <Route path="/perfil" component={Perfil} /> {/* Perfil */}

        <Route path="/notFound" component={NotFound} /> {/* Not Found */}
        <Redirect to="/notFound" /> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
