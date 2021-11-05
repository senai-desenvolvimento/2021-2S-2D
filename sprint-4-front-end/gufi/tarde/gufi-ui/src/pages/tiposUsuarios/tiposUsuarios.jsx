import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function TiposUsuarios() {

    // estrutura de declaração de um estado usando o Hook useState
    // const [ nomeEstado, funcaoAtualiza ] = useState( valorInicial )
    const [ listaTiposUsuarios, setListaTiposUsuarios ] = useState( [] );
    const [ titulo, setTitulo ] = useState( '' );
    const [ isLoading, setIsLoading ] = useState( false );

    // função responsável por fazer a requisição e trazer a lista de tipos usuários
    function buscarTiposUsuarios(){
        console.log('Agora vamos fazer a chamada para a API.')

        // faz a chamada para a API usando axios
        axios('http://localhost:5000/api/tiposusuarios', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta => {
            // console.log(resposta)
            if (resposta.status === 200) {
                // estrutura set...
                // setListaTiposUsuarios( novoValor )
                setListaTiposUsuarios( resposta.data )
            }
        })
        .catch( erro => console.log(erro) );
    };

    // estrutura de declaração do Hook useEffect
    // useEffect( efeito, causa );
    // useEffect( { o que vai ser feito }, { o que será escutado } );
    // dessa forma, a função buscarTipoUsuarios será invocada apenas uma vez pelo useEffect
    useEffect( buscarTiposUsuarios, [] );

    function cadastrarTipoUsuario(evento){
        setIsLoading( true );

        // evita o comportamento padrão do navegador
        evento.preventDefault();

        axios.post('http://localhost:5000/api/tiposusuarios', {
            tituloTipoUsuario : titulo
        }, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(response => {
            if (response.status === 201) {
                console.log('O tipo de usuário foi cadastrado com sucesso!');
                setTitulo( '' );
                buscarTiposUsuarios();
                setIsLoading( false );
            }
        })
        .catch( erro => console.log(erro), setTitulo( '' ), setInterval(() => {
            setIsLoading( false )
        }, 5000) );
    };

    // console.log(titulo);

    return (
        <div>

            <main>

                <section>
                    <h2>Lista Tipos de Usuários</h2>
                    
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
                                        return(
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
                    <h2>Cadastro de tipo de usuário</h2>

                    <form onSubmit={cadastrarTipoUsuario} >
                        <div>
                            <input 
                                type="text"
                                value={titulo}
                                onChange={ (campo) => setTitulo( campo.target.value ) }
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

                            {
                                // outra forma
                                // isLoading === false ? (
                                //     <button type="submit">Cadastrar</button>
                                // ) : (
                                //     <button type="submit" disabled>Carregando...</button>
                                // )
                            }
                        </div>
                    </form>
                    
                </section>

            </main>

        </div>
    )
};