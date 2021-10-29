import { Component } from 'react';
import axios from 'axios';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            erroMensagem : '',
            isLoading : false
        };
    };

    // Função que faz a chamada para a API para realiza o login
    efetuaLogin = (event) => {
        // ignora o comportamento padrão do navegador (recarregar a página, por exemplo)
        event.preventDefault();

        this.setState({ erroMensagem : '', isLoading : true });

        axios.post('http://localhost:5000/api/Login', {
            email : this.state.email,
            senha : this.state.senha
        })

        // recebe todo o conteúdo da resposta da requisição na variável resposta
        .then(resposta => {
            // verifico se o status code dessa resposta é igual a 200
            if (resposta.status === 200) {
                // se sim, exibe no console do navegador o token do usuário logado,
                console.log('Meu token é: ' + resposta.data.token);
                // salva o valor do token no localStorage
                localStorage.setItem('usuario-login', resposta.data.token);
                // e define que a requisição terminou
                this.setState({ isLoading : false })
            }
        })

        // Caso haja um erro,
        .catch(() => {
            // define o valor do state erroMensagem com uma mensagem personalizada
            this.setState({ erroMensagem : 'E-mail e/ou senha inválidos!', isLoading : false })
        })
    };

    atualizaStateCampo = (campo) => {
        // quando estiver digitando no campo username
        //                     email        :       adm@adm.com

        // quando estiver digitando no campo password
        //                     senha        :        senha123
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div>

                <main>
                    <section>
                        <p>Bem vindo(a)! <br/> Faça login para acessar a sua conta.</p>

                        {/* Faz a chamada para a função de login quando o botão é pressionado */}

                        <form onSubmit={this.efetuaLogin}>
                            <input 
                                // e-mail
                                type="text"
                                name="email"
                                // define que o input email recebe o valor do state email
                                value={this.state.email}
                                // faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                                onChange={this.atualizaStateCampo}
                                placeholder="username"
                            />

                            <input 
                                // senha
                                type="password"
                                name="senha"
                                // define que o input senha recebe o valor do state senha
                                value={this.state.senha}
                                // faz a chamada para a função que atualiza o state, conforme o usuário altera o valor do input
                                onChange={this.atualizaStateCampo}
                                placeholder="password"
                            />

                            {/* Exibe a mensagem de erro ao tentar logar com credenciais inválidas */}
                            <p style={{ color : 'red' }} >{this.state.erroMensagem}</p>

                            {/* 
                                Verifica se a requisição está em andamento
                                Se estiver, desabilita o click do botão
                            */}

                            {
                                // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                this.state.isLoading === true &&
                                <button type="submit" disabled>
                                    Loading...
                                </button>
                            }

                            {
                                // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                this.state.isLoading === false &&
                                <button 
                                    type="submit"
                                    disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : '' }>
                                    Login
                                </button>
                            }

                        </form>
                    </section>
                </main>

            </div>
        )
    }
};