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

    efetuaLogin = (event) => {
        event.preventDefault();

        this.setState({ erroMensagem : '', isLoading : true })

        axios.post('http://localhost:5000/api/Login', {
            email : this.state.email,
            senha : this.state.senha
        })

        .then(response => {
            if (response.status === 200) {

                localStorage.setItem('usuario-login', response.data.token)

                console.log('Meu token é: ' + response.data.token);

                this.setState({ isLoading : false })
            }
        } )

        .catch(() => {
            this.setState({ erroMensagem : 'E-mail ou senha inválidos!', isLoading : false })
        });

    };

    // Função genérica que atualiza o state de acordo com o input
    atualizaStateCampo = (campo) => {
        //                      email       :     adm@adm.com
        //                      senha       :       adm12345
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <div>

                <main>
                    <section>
                        <p>Bem vindo(a)! <br/> Faça login para acessar sua conta.</p>

                        {/* Faz a chamada para a função de login quando o botão é pressionado */}

                        <form onSubmit={this.efetuaLogin}>
                            <input 
                                // email
                                type="email"
                                // obs.: o name do input deve ser igual ao nome da propriedade dentro do objeto state
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

                            <p style={{ color : 'red' }} >{this.state.erroMensagem}</p>

                            {/* 
                                Verifica se a requisição está em andamento
                                Se estiver, desabilita o click do botão
                            */}

                            {
                                // caso isLoading seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                this.state.isLoading === true &&
                                <button type="submit" disabled>Loading...</button>
                            }

                            {
                                // caso isLoading seja false, renderiza o botão habilitado com o texto 'Login'

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