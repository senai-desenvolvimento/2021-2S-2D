import { Component } from 'react';
//imagens
import logo from "../../assets/img/logo.png"
import Rodape from '../../components/rodape/rodape';
import Titulo from '../../components/titulo/titulo';


export default class TiposEventos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaTiposEventos : [],
            titulo : '',
            idTipoEventoAlterado : 0,
            titulosecao: "Lista Tipos Eventos"
        };
    };

    buscarTiposEventos = () => {
        console.log("agora vamos fazer a chamada para a API")

        // informamos o end point.

        fetch('http://localhost:5000/api/TiposEventos')
            // nessa linha vamos 
            // enviar a requiscao
            // por padrao será um GET.

            //entao, quando vc tiver um retorno, pegue essa resposta e deixe
            //em formato JSON.

            //Define o tipo de dados do retorno da aplicacao como JSON.

            //THEN = ENTÃO;

            .then(resposta => resposta.json())

            //THEN = ENTÃO;

            ////atualizado o statis listaTiposEventos com os dados obtidos.
            .then(dados => this.setState({ listaTiposEventos: dados }))

            //caso ocorra algum erro, mostra no console do computador.
            .catch(erro => console.log(erro))

        //.then( resposta => resposta.json())

        //.then( dados => console.log(dados) )

        /*fetch('http://localhost:5000/api/TipoEventos').then( resposta => resposta.json())
        .then( dados => this.setState({ listaTiposEventos: dados }) )
        .catch(erro => console.log(erro))*/
    }

    componentDidMount() {
        this.buscarTiposEventos();
    };

    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadodoTitulo = async (event) => {
        //Nome titulo > valor input.
        await this.setState({ titulo: event.target.value })
        console.log(this.state.titulo)
    }

    // Função responsável por manipular um tipo de evento, seja para cadastro ou para edição
    cadastrarTipoEvento = (event) => {
        // Ignora o comportamento padrão do navegador
        event.preventDefault();

        if (this.state.idTipoEventoAlterado !== 0) {
            // Segue para o processo de atualização

            // http://localhost:5000/api/tiposeventos/4
            fetch('http://localhost:5000/api/tiposeventos/' + this.state.idTipoEventoAlterado, {
                method : 'PUT',
                body : JSON.stringify({ tituloTipoEvento : this.state.titulo }),
                headers : {
                    "Content-type" : "application/json"
                }
            })

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log(
                        'O Tipo de Evento ' + this.state.idTipoEventoAlterado + ' foi atualizado!',
                        'Seu novo título agora é :' + this.state.titulo
                    )
                }
            })

            // caso ocorra algum erro, mostra no console do navegador
            .catch(erro => console.log(erro))

            .then(this.buscarTiposEventos)

            .then(this.limparCampos);
        }

        else {
            fetch('http://localhost:5000/api/TiposEventos', {

            method: 'POST',
            //body: { tituloTipoEvento = this.state.titulo } //lembrando que aqui é o objeto JS, e nao JSON;

            body: JSON.stringify({ tituloTipoEvento: this.state.titulo }),

            headers: { "Content-Type": "application/json" }
        })

            .then(console.log("Tipo de evento cadastrado."))

            //caso ocorra algum erro, mostra no console do navegador.
            .catch(erro => console.log(erro))

            //entao, atualiza a lista de tipos de evento.

            .then(this.buscarTiposEventos)

            .then(this.limparCampos);
        }        
    }

    // Recebe um tipo de evento da lista
    buscarTipoEventoPorId = (tipoEvento) => {
        this.setState({
            // Atualiza o state idTipoEventoAlterado com o valor do ID do Tipo de Evento recebido
            idTipoEventoAlterado : tipoEvento.idTipoEvento,
            // e o state titulo com o valor do título do Tipo de Evento recebido
            titulo : tipoEvento.tituloTipoEvento
        }, () => {
            console.log(
                // Exibe no console do navegador o valor do ID do Tipo de Evento recebido,
                'O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado, ' +
                // o valor do state idTipoEventoAlterado
                'agora o valor do state idTipoEventoAlterado é: ' + this.state.idTipoEventoAlterado,
                // e o valor do state titulo
                'e o valor do state título é: ' + this.state.titulo
            )
        })
    };

    exlcuirTipoEvento = (tipoEvento) => {
        console.log('O Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi selecionado!');
        
        fetch('http://localhost:5000/api/TiposEventos/' + tipoEvento.idTipoEvento, {
            method : 'DELETE'
        })

        .then(resposta => {
            if (resposta.status === 204) {
                // deu certo
                console.log('Tipo de Evento ' + tipoEvento.idTipoEvento + ' foi excluído!')
            }
        })

        // caso ocorra algum erro, mostra no console do navegador.
        .catch(erro => console.log(erro))

        .then(this.buscarTiposEventos);
    };

    // Reseta os states titulo e idTipoEventoAlterado
    limparCampos = () => {
        this.setState({
            titulo : '',
            idTipoEventoAlterado : 0
        })
        // Exibe no console do navegador a mensagem abaixo
        console.log('Os states foram resetados!')
    };

    render() {
        return (
            // JSX
            <div>
                  <header className="cabecalhoPrincipal">
                    <div className="container">
                    <img src={logo} alt="Logo da Gufi" />

                    <nav className="cabecalhoPrincipal-nav">
                        Administrador
                    </nav>
                    </div>
                </header>
                <main  className="conteudoPrincipal">
                    {/* Lista de tipos de eventos */}
                    <section className="conteudoPrincipal-cadastro">
                    <Titulo titulosecao={this.state.titulosecao} />
                    {/* <h2 class="conteudoPrincipal-cadastro-titulo">Tipos de Eventos</h2> */}
                       <div className="container" id="conteudoPrincipal-lista">
            
                            <table id="tabela-lista">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Título</th>
                                        <th>Ações</th>
                                    </tr>
                                </thead>

                                <tbody id="tabela-lista-corpo">
                                    {
                                        this.state.listaTiposEventos.map((tipoEvento) => {
                                            return (
                                                <tr key={tipoEvento.idTipoEvento}>
                                                    <td>{tipoEvento.idTipoEvento}</td>
                                                    <td>{tipoEvento.tituloTipoEvento}</td>

                                                    {/* Faz a chamada da função buscarTipoEventoPorId passando o Tipo de Evento selecionado como parâmetro */}
                                                    <td><button onClick={() => this.buscarTipoEventoPorId(tipoEvento)}>Editar</button>
                                                    <button onClick={() => this.exlcuirTipoEvento(tipoEvento)}>Excluir</button></td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </table>
                          </div>  
                    </section>

                    {/* Cadastro de tipos de eventos */}

                    <section className="container" id="conteudoPrincipal-cadastro">

                        <Titulo titulosecao="Cadastro de Tipo de Evento" />
                         {/* <h2  className="conteudoPrincipal-cadastro-titulo">Cadastro de tipo de evento</h2>  */}
                        <form onSubmit={this.cadastrarTipoEvento}>
                            <div className="container">
                                <input 
                                    type="text"
                                    //atualiza o tipo de input
                                    //valor do status é do input
                                    value={this.state.titulo}
                                    placeholder="Titulo do Tipo de Evento"
                                    //cada vez que tiver uma mudanca (por tecla)
                                    onChange={this.atualizaEstadodoTitulo}
                                />

                                {/* quando clicar em cadastrar temos que submeter o formulario */}
                                {/* <button type="submit">Cadastrar</button> */}

                                {/* Altera o texto do botão de acordo com a operação ( edição ou cadastro ) usando IF Ternário */}

                                {/* 
                                    Estrutura do IF Ternário
                                    CONDIÇÃO ? FAZ ALGO CASO VERDADEIRO : FAZ ALGO CASO FALSO
                                */}

                                {/* {
                                    this.state.idTipoEventoAlterado === 0 ?
                                    <button type="submit">Cadastrar</button> :
                                    <button type="submit">Atualizar</button>
                                } */}

                                {/* 
                                    Uma outra forma, com IF Ternário e disabled ao mesmo tempo
                                */}

                                {
                                    <button type="submit" className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" disabled={this.state.titulo === '' ? 'none' : ''}>
                                        {this.state.idTipoEventoAlterado === 0 ? 'Cadastrar' : 'Atualizar'}
                                    </button>
                                }

                                <button type="button" className="conteudoPrincipal-btn conteudoPrincipal-btn-cadastro" onClick={this.limparCampos} style={{ display : '' }}>
                                    Cancelar
                                </button>

                                {/* 
                                    Caso algum Tipo de Evento tenha sido selecionado para edição,
                                    exibe a mensagem de feedback ao usuário
                                */}

                                {
                                    this.state.idTipoEventoAlterado !== 0 &&
                                    <div>
                                        <p>O tipo de evento {this.state.idTipoEventoAlterado} está sendo editado!</p>
                                        <p>Clique em Cancelar caso queira cancelar a operação antes de cadastrar um novo tipo de evento.</p>
                                    </div>
                                }
                            </div>
                        </form>
                    </section>
                </main>
                <Rodape />
            </div>
        )
    }
};