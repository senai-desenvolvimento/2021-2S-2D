import { React, Component } from 'react';
import axios from 'axios';

export default class Perfilfoto extends Component {
  constructor(props) {
    super(props);
    this.state = {
      base64img: '',
    };
  }
  buscaImg = () => {
    axios('http://localhost:5000/api/perfil/imagem/bd', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      },
    })
      .then((resposta) => {
        if (resposta.status === 200) {
          this.setState({ base64img: resposta.data });
        }
      })
      .catch((erro) => console.log(erro));
  };
  componentDidMount() {
    this.buscaImg();
  }

  render() {
    return (
      <img
        className="radius-img"
        alt="Imagem do Perfil"
        src={`data:image;base64,${this.state.base64img}`}
      />
    );
  }
}
