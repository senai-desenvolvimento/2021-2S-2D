import { Component } from 'react';

export default class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaTiposEventos : [ { idTipoEvento : 1, titulo : 'C#' }, { idTipoEvento : 2, titulo : 'SQL' }, { idTipoEvento : 3, titulo : 'ReactJS' } ],
            titulo : ''
        };
    };

    componentDidMount(){
        //
    };

    render(){
        return(
            // JSX
            <div>
                <main>
                    {/* Lista de tipos de eventos */}
                    <section>
                        <h2>Lista de tipos de eventos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Título</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.listaTiposEventos.map( (tipoEvento) => {
                                        return(
                                            <tr key={tipoEvento.idTipoEvento}>
                                                <td>{tipoEvento.idTipoEvento}</td>
                                                <td>{tipoEvento.titulo}</td>
                                            </tr>
                                        )
                                    } )                                 
                                }
                            </tbody>
                        </table>
                    </section>

                    {/* Cadastro de tipos de eventos */}
                </main>
            </div>
        )
    }
};