import { React, Component } from 'react';
import axios from 'axios';

export default class Eventos extends Component {
    constructor(props){
        super(props);
        this.state = {
          
        }
    };

    componentDidMount(){

    }
    
    render(){

        return(
            <>
                <main>
                    <section>
                        {/* Lista de Eventos */}
                        <h2>Lista de Eventos</h2>
                        <table>
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
                               
                            </tbody>
                        </table>
                    </section>

                    <section>
                        {/* Cadastro de Eventos */}
                        <h2>Cadastro de Eventos</h2>
                      
                    </section>
                </main>
            </>
        );
    };
};