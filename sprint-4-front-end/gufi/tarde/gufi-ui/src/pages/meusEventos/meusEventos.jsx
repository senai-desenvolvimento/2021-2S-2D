import { useState, useEffect } from 'react';
import axios from 'axios';

export default function MeusEventos(){
    const [ listaMeusEventos, setListaMeusEventos ] = useState( [] );

    function buscarMeusEventos(){
        axios('http://localhost:5000/api/presencas/minhas', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
        .then(response => {
            if (response.status === 200) {
                // console.log(response);
                setListaMeusEventos( response.data );
            }
        })
        .catch( erro => console.log(erro) );
    };
    
    useEffect( buscarMeusEventos, [] );

    return(
        <div>

            <main>
                <section>
                    <h2>Meus Eventos</h2>

                    <div>
                        <table style={{ borderCollapse : 'separate', borderSpacing : 30 }}>

                            <thead>
                                <tr>
                                    <th>Evento</th>
                                    <th>Descrição</th>
                                    <th>Data</th>
                                    <th>Acesso</th>
                                    <th>Situação</th>
                                    <th>Tipo de Evento</th>
                                    <th>Localização</th>
                                </tr>
                            </thead>

                            <tbody>

                                {
                                    listaMeusEventos.map( (minhaPresenca) => {
                                        return(
                                            <tr key={minhaPresenca.idPresenca}>
                                                <td>{minhaPresenca.idEventoNavigation.nomeEvento}</td>
                                                <td>{minhaPresenca.idEventoNavigation.descricao}</td>
                                                <td>{ Intl.DateTimeFormat("pt-BR", {
                                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                                    hour: 'numeric', minute: 'numeric', hour12: true
                                                }).format(new Date(minhaPresenca.idEventoNavigation.dataEvento)) }</td>
                                                <td>{minhaPresenca.idEventoNavigation.acessoLivre ? 'Livre' : 'Restrito'}</td>
                                                <td>{minhaPresenca.idSituacaoNavigation.descricao}</td>
                                                <td>{minhaPresenca.idEventoNavigation.idTipoEventoNavigation.tituloTipoEvento}</td>
                                                <td>{minhaPresenca.idEventoNavigation.idInstituicaoNavigation.endereco}</td>
                                            </tr>
                                        )
                                    } )                                
                                }
                                
                            </tbody>

                        </table>
                    </div>
                </section>
            </main>

        </div>
    )
};