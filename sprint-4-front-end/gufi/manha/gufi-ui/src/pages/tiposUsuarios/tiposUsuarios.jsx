import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function TiposUsuarios(){
    // não precisamos de constructor em componentes funcionais
    // e nem da função render()

    // estrutura do state criado através do Hook useState:
    // const [ nomeState, funcaoAtualiza ] = useState( valorInicial );

    // define o state listaTiposUsuarios, a função setListaTiposUsuarios que vai atualizar este state
    // e define que o valor inicial deste state é um array vazio
    const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState( [] );
    const [ titulo, setTitulo ] = useState( '' );
    const [ isLoading, setIsLoading ] = useState( false );

    // função responsável por fazer a requisição e trazer a lista de tipos usuários
    function buscarTiposUsuarios() {
        console.log('vamos fazer a chamada para a API');

        // faz a chamada para a API usando axios
        axios('http://localhost:5000/api/tiposusuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // caso a resposta da requisição tenha um status code igual a 200
            if (resposta.status === 200) {
                // console.log(resposta.data)
                // atualiza o state listaTiposUsuarios com os dados do corpo da resposta
                setListaTiposUsuarios(resposta.data)
            }
        } )

        // caso ocorra algum erro, exibe no console do navegador este erro
        .catch(erro => console.log(erro));
    };

    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect( buscarTiposUsuarios, [] );

    // função responsável por fazer a requisição que cadastra um novo tipo de usuário
    function cadastrarTipoUsuario(evento) {
        // evita o comportamento padrão do navegador
        evento.preventDefault();

        // define que uma requisição está em andamento
        setIsLoading( true );

        if (listaTiposUsuarios) {
            // verifica se existe na lista algum tipo de usuário igual ao que está sendo passado pelo usuário
        }
        
        // faz a chamada para a API
        axios.post('http://localhost:5000/api/tiposusuarios', {
            tituloTipoUsuario : titulo
        }, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // se o status code da resposta da requisição for igual a 201
            if (resposta.status === 201) {
                // exibe a mensagem no console do navegador,
                console.log('Tipo de usuário cadastrado!');
                // atualiza a lista de tipos de usuário automaticamente,
                buscarTiposUsuarios();
                // reseta o valor do state titulo,
                setTitulo('');
                // e volta o valor do state isLoading para false
                setIsLoading( false );
            }
        })
        // caso ocorra algum erro, exibe no console do navegador este erro
        // e volta o valor do state isLoading para false
        .catch(erro => console.log(erro), setInterval(() => {
            setIsLoading( false )
        }, 5000));
    };

    // exibe no console o valor do state titulo a cada alteração feita pelo usuário
    console.log(titulo);

    return(
        <div>

            <main>
                <section>
                    <h2>Tipos de Usuários</h2>

                    <div>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>

                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    listaTiposUsuarios.map( (tipoUsuario) => {
                                        return (
                                            <tr key={tipoUsuario.idTipoUsuario}>
                                                <td>{tipoUsuario.idTipoUsuario}</td>
                                                <td>{tipoUsuario.tituloTipoUsuario}</td>
                                            </tr>
                                        )
                                    } )
                                }
                            </tbody>

                        </table>
                    </div>
                </section>

                <section>
                    <h2>Cadastro de Tipo de Usuário</h2>

                    <p>O tipo de usuário {titulo} está sendo cadastrado </p>

                    <form onSubmit={cadastrarTipoUsuario}>
                        <div>
                            <input 
                                type="text" 
                                value={titulo}
                                onChange={ (campo) => setTitulo(campo.target.value) }
                                placeholder="Título do tipo de usuário"
                            />

                            {/* <button type="submit">Cadastrar</button> */}

                            {
                                isLoading === false &&
                                <button type="submit">Cadastrar</button>
                            }

                            {
                                isLoading === true &&
                                <button type="submit" disabled>Carregando...</button>
                            }

                            {/* {
                                outra forma:

                                isLoading === false ? (
                                    <button type="submit">Cadastrar</button>
                                 ) : ( 
                                    <button type="submit" disabled>Carregando...</button>
                                 )
                            } */}
                        </div>
                    </form>
                </section>
            </main>

        </div>
    )
};