import { React, Component } from 'react';
import axios from 'axios';

import { Link } from 'react-router-dom';
import logo from '../../assets/img/logo.png';
import Titulo from '../../components/titulo/titulo';
import Perfilfoto from '../../components/perfilfoto/perfilfoto';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      arquivo: '',
      base64img: '',
    };
  }

  enviarArquivo = () => {
    console.log('envio');
    if (this.state.arquivo !== '') {
      const formData = new FormData();

      //FormData  - maneira facil para construir um conjunto de chave/valor, para ser utilizado no método send().

      //FormaData.append Acrescenta um novo valor em uma chave existente dentro de um objeto FormData, ou adiciona a chave se ela ainda não existir.

      formData.append(
        'arquivo', // chave, nome do arquivo que será enviado.
        this.state.arquivo, //valor, arquivo fisico
      );

      axios
        .post('http://localhost:5000/api/perfil/imagem/bd', formData, {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
          },
        })
        .then(console.log('Upload Realizado'))
        .catch((erro) => console.log(erro))
        .then(this.buscaImg);
    } else {
      console.log('Nenhum arquivo selecionado.');
    }
  };

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

  atualizaState = (event) => {
    console.log(event);
    this.setState({ arquivo: event.target.files[0] });
  };

  render() {
    return (
      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
            <Link to="/">
              <img src={logo} alt="Logo da Gufi" />{' '}
            </Link>
            <nav className="cabecalhoPrincipal-nav">Administrador
          
            
            </nav>

           <nav>
               <Perfilfoto />
           </nav>

          </div>
        </header>
        <main className="conteudoPrincipal">
        <section className="conteudoPrincipal-cadastro">
            <Titulo titulosecao="Imagem do Perfil" />
            <div className="container" id="conteudoPrincipal-lista">
              <input type="file" onChange={this.atualizaState} />
              <button onClick={this.enviarArquivo}>Upload!</button>
              {/* src vai carregar no data uma imagem do tipo base64   */}
              <div className="container" id="conteudoPrincipal-lista">
                <h2>Upload de Imagem</h2>
                <img className="radius-img"
                  alt="Imagem do Perfil"
                  src={`data:image;base64,${this.state.base64img}`}
                />
              </div>
            </div>
          </section>
        </main>
      </div>
    );
  }
}
