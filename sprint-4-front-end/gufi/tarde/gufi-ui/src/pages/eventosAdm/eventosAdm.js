import { React, Component } from 'react';
import axios from 'axios';

export default class EventosAdm extends Component {
  constructor(props) {
    super(props);

    //nome e valor inicial
    this.state = {
      titulo: '',
      descricao: '',
      dataEvento: new Date(), //inicialmente vai ser do tipo Date().
      acessoLivre: 0, // 0 false, 1 true.
      idTipoEvento: 0,
      idInstituicao: 0,

      listaTiposEventos: [],
      listaInstuicao: [],
      listaEventos: [],
      isLoading: false,
    };
  }

  //listar tipos eventos

  // funcao responsável por fazer a requisição e trazer a lista de tipos eventos.
  buscarTiposEventos = () => {
    // o metodo GET é padrão.
    axios('http://localhost:5000/api/TiposEventos', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      },
    })
      .then((resposta) => {
        //caso a requisicao retorne Ok ( status code 200)
        if (resposta.status === 200) {
          //atualiza o status  listaTiposEventos como os dados obtidos.
          this.setState({ listaTiposEventos: resposta.data });
          console.log(this.state.listaTiposEventos);
        }
      })
      //caso ocorra algum erro, mostra no console do navegador.
      .catch((erro) => console.log(erro));
  };

  //listar instituicao
  buscarInstituicoes = () => {
    axios('http://localhost:5000/api/Instituicoes', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
      },
    })
      .then((resposta) => {
        //caso a requisicao retorne Ok ( status code 200)
        if (resposta.status === 200) {
          //atualiza o status  listaInstuicao como os dados obtidos.
          this.setState({ listaInstuicao: resposta.data });
          console.log(this.state.listaInstuicao);
        }
      })
      //caso ocorra algum erro, mostra no console do navegador.
      .catch((erro) => console.log(erro));
  };

  //listar eventos
  buscarEventos = () => {
    axios('http://localhost:5000/api/Eventos')
      .then((resposta) => {
        if (resposta.status === 200) {
          this.setState({ listaEventos: resposta.data });
          console.log(this.state.listaEventos);
        }
      })
      .catch((erro) => console.log(erro));
  };

  //cadastro

  //funcao que faz a chamada para API para cadastrar um evento.
  cadastrarEvento = (event) => {
    //Ignora o comportamento padrao do navegador.
    event.preventDefault();
    this.setState({ isLoading: true });

    let evento = {
      nomeEvento: this.state.titulo,
      descricao: this.state.descricao,
      dataEvento: new Date(this.state.dataEvento),
      acessoLivre: parseInt(this.state.acessoLivre),
      idTipoEvento: this.state.idTipoEvento,
      idInstituicao: this.state.idInstituicao,
    };

    axios
      .post('http://localhost:5000/api/Eventos', evento, {
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
        },
      })
      .then((resposta) => {
        if (resposta.status === 201) {
          console.log('Evento cadastrado!');
          this.setState({ isLoading: false });
        }
      })
      .catch((erro) => {
        console.log(erro);
        this.setState({ isLoading: false });
      })
      .then(this.buscarEventos);
  };

  atualizaStateCampo = (campo) => {
    // quando estiver digitando no campo username
    //                     email        :       adm@adm.com

    // quando estiver digitando no campo password
    //                     senha        :        senha123
    this.setState({ [campo.target.name]: campo.target.value });
  };

  componentDidMount() {
    //ciclo de vida de criação.
    this.buscarTiposEventos();
    this.buscarInstituicoes();
    this.buscarEventos();
  }

  render() {
    return (
      <>
        <main>
          <section>
            {/* Lista de Eventos */}
            <h2>Lista de Eventos</h2>
            <table style={{ borderCollapse: 'separate', borderSpacing: 30 }}>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Evento</th>
                  <th>Descrição</th>
                  <th>Data</th>
                  <th>Acesso Livre</th>
                  <th>Tipo de Evento</th>
                  <th>Localização</th>
                </tr>
              </thead>

              <tbody>
                {this.state.listaEventos.map((evento) => {
                  return (
                    <tr key={evento.idEvento}>
                      <td>{evento.idEvento}</td>
                      <td>{evento.nomeEvento}</td>
                      <td>{evento.descricao}</td>
                      <td>{evento.dataEvento}</td>
                      <td>{evento.acessoLivre ? 'Livre' : 'Restrito'}</td>
                      <td>{evento.idTipoEventoNavigation.tituloTipoEvento}</td>
                      <td>{evento.idInstituicaoNavigation.endereco}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </section>

          <section>
            {/* Cadastro de Eventos */}
            <h2>Cadastro de Eventos</h2>

            <form onSubmit={this.cadastrarEvento}>
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  width: '20vw',
                }}
              >
                <input
                  type="text"
                  name="titulo"
                  value={this.state.titulo}
                  onChange={this.atualizaStateCampo}
                  placeholder="Título do Evento"
                />

                <select
                  name="idTipoEvento"
                  value={this.state.idTipoEvento}
                  onChange={this.atualizaStateCampo}
                >
                  <option value="0">Selecione o tema do evento.</option>

                  {this.state.listaTiposEventos.map((tema) => {
                    return (
                      <option key={tema.idTipoEvento} value={tema.idTipoEvento}>
                        {tema.tituloTipoEvento}
                      </option>
                    );
                  })}
                </select>

                <input
                  required
                  type="text"
                  name="descricao"
                  value={this.state.descricao}
                  onChange={this.atualizaStateCampo}
                  placeholder="Descrição do Evento"
                />

                <input
                  type="date"
                  name="dataEvento"
                  value={this.dataEvento}
                  onChange={this.atualizaStateCampo}
                />

                <select
                  name="acessoLivre"
                  value={this.state.acessoLivre}
                  onChange={this.atualizaStateCampo}
                >
                  <option value="1">Livre</option>
                  <option value="0">Restrito</option>
                </select>

                <select
                  name="idInstituicao"
                  value={this.state.idInstituicao}
                  onChange={this.atualizaStateCampo}
                >
                  <option value="0">Selecione a Instituição.</option>

                  {this.state.listaInstuicao.map((local) => {
                    return (
                      <option
                        key={local.idInstituicao}
                        value={local.idInstituicao}
                      >
                        {local.nomeFantasia}
                      </option>
                    );
                  })}
                </select>

                {this.state.isLoading && (
                  <button type="submit" disabled>
                    Loading...{' '}
                  </button>
                )}

                {this.state.isLoading === false && (
                  <button type="submit">Cadastrar</button>
                )}
              </div>
            </form>
          </section>
        </main>
      </>
    );
  }
}
