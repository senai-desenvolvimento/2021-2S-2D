import { React, Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import logo from '../../assets/img/logo.png';
import Titulo from '../../components/titulo/titulo';
import Rodape from '../../components/rodape/rodape';
import PerfilFoto from '../../components/perfilfoto/perfilfoto';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      imagem64: '',
      arquivo: null,
    };
  }
  upload = () => {   
    const formData = new FormData();
    formData.append(
      'arquivo', //chave, nome do arquivo que será enviado.
      this.state.arquivo, // valor, arquivo físico
    );

    axios
      .post('http://localhost:5000/api/perfils/imagem/bd', formData, {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
      })
      .catch((erro) => console.log(erro))
      .then(this.buscarImagem);
  };

  atualizaState = (event) => {
    console.log(event);
    this.setState({ arquivo: event.target.files[0] });
  };

  buscarImagem = () => {
    axios('http://localhost:5000/api/perfils/imagem/bd', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      },
    })
      .catch((erro) => console.log(erro))
      .then((resposta) => {
        if (resposta.status === 200) {
          console.log(resposta);
          this.setState({ imagem64: resposta.data });
        }
      });
  };

  componentDidMount() {
    this.buscarImagem();
  }

  render() {
    return (
      <div>
        <header className="cabecalhoPrincipal">
          <div className="container">
            <Link to="/">
              <img src={logo} alt="Logo da Gufi" />
            </Link>
            <nav className="cabecalhoPrincipal-nav">Administrador
           
               <PerfilFoto />
              

            </nav>
           
          </div>
        </header>

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">
            <Titulo titulosecao="Imagem do Perfil" />
            <div className="container" id="conteudoPrincipal-lista">
              <h2>Upload de Imagem</h2>
              <input type="file" onChange={this.atualizaState} />              
                  
                {
                    this.state.arquivo === null ?
                    <button disabled className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" onClick={this.upload} >Enviar! </button>
                     :
                     <button  className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" onClick={this.upload} >Enviar! </button>
                }

             
            </div>
            <div className="container" id="conteudoPrincipal-lista">
              <img className="imagem-header"
                src={`data:image;base64,${this.state.imagem64}`}
                alt="Imagem de Perfil"
              />
            </div>
          </section>
        </main>
        <Rodape />
      </div>
    );
  }
}
