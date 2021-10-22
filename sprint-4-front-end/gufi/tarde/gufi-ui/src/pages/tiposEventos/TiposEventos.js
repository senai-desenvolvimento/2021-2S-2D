import { Component } from 'react';

export default class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaTiposEventos : [],
            titulo : ''
        };
    };

   
    buscarTiposEventos = () => {
        console.log("agora vamos fazer a chamada para a API")

     //Informamos o end point.

    fetch('http://localhost:5000/api/TipoEventos')  //nessa linha vamos 
                                       //enviar a requiscao
     //por padrao será um GET.
     

     //entao, quando vc tiver um retorno, pegue essa resposta e deixe
     //em formato JSON.

     //Define o tipo de dados do retorno da aplicacao como JSON.

     //THEN = ENTÃO;

    .then( resposta => resposta.json())

     //THEN = ENTÃO;

    ////atualizado o statis listaTiposEventos com os dados obtidos.
    .then( dados => this.setState({ listaTiposEventos: dados }) )
  
    //caso ocorra algum erro, mostra no console do computador.
    .catch(erro => console.log(erro))

    //.then( resposta => resposta.json())

    //.then( dados => console.log(dados) )


    /*fetch('http://localhost:5000/api/TipoEventos').then( resposta => resposta.json())
    .then( dados => this.setState({ listaTiposEventos: dados }) )
    .catch(erro => console.log(erro))*/


    }


    componentDidMount(){
          this.buscarTiposEventos()
                  //
    };

    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadodoTitulo = async (event) => {

                         //Nome titulo > valor input.
        await this.setState({  titulo: event.target.value })
         console.log(this.state.titulo)

    }


    cadastrarTipoEvento = (event) => {
        event.preventDefault();

        fetch('http://localhost:5000/api/TipoEventos', {

               method:'POST',
               //body: { tituloTipoEvento = this.state.titulo } //lembrando que aqui é o objeto JS, e nao JSON;

               body: JSON.stringify({ tituloTipoEvento : this.state.titulo }),
               headers:{ "Content-Type" :"application/json"}})

            .then(console.log("Tipo de evento cadastrado."))

                   //caso ocorra algum erro, mostra no console do navegador.
            .catch(erro => console.log(erro))

             //entao, atualiza a lista de tipos de evento.

            .then(this.buscarTiposEventos)

            .then(this.setState({ titulo: ''}))

    }



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
                                                <td>{tipoEvento.tituloTipoEvento}</td>
                                            </tr>
                                        )
                                    } )                                 
                                }
                            </tbody>
                        </table>
                    </section>

                   <section>
                          <h2>Cadastro de tipo de evento.</h2>
                          <form  onSubmit={this.cadastrarTipoEvento}>
                              <div>
                                    <input type="text" 

                                    //atualiza o tipo de input
                                    //valor do status é do input.
                                    value={this.state.titulo}  
                                    
                                    placeholder="Titulo do Tipo de Evento"

                                    //cada vez que tiver uma mudanca (por tecla)
                                    onChange={this.atualizaEstadodoTitulo}                                    
                                    
                                    />

                                    {/** quando clicar em cadastrar temo que submeter o formulario. */}
                                    <button type="submit" >Cadastrar</button>
                              </div>                   

                          </form>                    



                   </section>


                    {/* Cadastro de tipos de eventos */}
                </main>
            </div>
        )
    }
};