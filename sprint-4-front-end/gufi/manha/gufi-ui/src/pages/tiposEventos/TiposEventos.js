import { Component } from "react";

export default class TiposEventos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaTiposEventos : [],
            titulo : ''
        }
    };


    buscarTipoEventos = () => {
        console.log('agora vamos fazer a chamada para a api.')

        //funcao nativa JS, ele é uma API com métodos.

        //dentro dos parenteses vamos informar qual é o end point.
        fetch('http://localhost:5000/api/tipoeventos')
        //por padrao ele sempre inicia como GET.
        
        .then( resposta => resposta.json())

        //.then( dados => console.log(dados.json()))

        //quando vc tiver uma retorno, vc vai trazer essa resposta em json.

        //Define o tipo de dados do retorno da requisicao como JSON.
       
       // .then( resposta => resposta.json())
        
        //Atualiza o state listaTiposEventos com os dados obtidos em formato json.
        .then( dados => this.setState({ listaTiposEventos: dados }) )

        .then(this.setState({ titulo: '' }))

        //caso ocorre algum erro, mostra no console do navegador
        
        .catch( erro => console.log(erro))
    }


    //onChange vai disparar por tecla e invocar essa funcao.
    atualizaEstadoTitulo = async  (event) => {
         
        //console.log('acionou essa funcao')
        
        await this.setState({  
           //dizendo que o target (alvo) do evento ,  vamos pegar o value(valor) 
          titulo : event.target.value       

        })

        console.log(this.state.titulo);
    }



    cadastrarTipoEvento = (submit_formulario) => {
        submit_formulario.preventDefault();
  
        console.log(JSON.stringify({ tituloTipoEvento : this.state.titulo}))
  
          fetch('http://localhost:5000/api/tipoeventos', {
  
              method: 'POST',           
  
              body: JSON.stringify({ tituloTipoEvento : this.state.titulo}), //lembrado que aqui e um obj js e nao json.
   
              headers :{
                  "Content-Type" : "application/json"
              }
          })
             //Exibe no console a msg "Tipo de evento cadastrado"
          .then(console.log("Tipo de evento cadastrado."))
  
          //caso ocorra algum erro, mostra no console do navegador.
          .catch(erro => console.log(erro))  

          .then(this.buscarTipoEventos)

  
     }



    componentDidMount(){        
         this.buscarTipoEventos() 
        //
    }

    render(){
        return(
            <div>
                <main>
                    {/* Lista de Tipos de Eventos */}
                    <section>
                            <h2>Lista de Tipos de Eventos</h2>
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
                                            //console.log(tipoEvento)
                                            return (
                                                <tr key={tipoEvento.idTipoEvento}>
                                                    <td>{tipoEvento.idTipoEvento}</td>
                                                    <td>{tipoEvento.tituloTipoEvento}</td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                       </table>
                    </section>

                    <section>
                        {/**Cadastro por tipo de evento */}
                          <h2>Cadastro de tipo de evento</h2>                          
                          <form  onSubmit={this.cadastrarTipoEvento}  >
                              <div>
                                {/**   //valor do state é o input */}
                                   <input type="text" value={ this.state.titulo }
                                    
                                     placeholder="Título do Tipo de Evento"
                                    
                                     //cada vez que tiver uma mudanca, (por tecla)
                                     onChange={this.atualizaEstadoTitulo}                                     
                                   
                                   />
                                   <button type="submit" >Cadastrar</button>

                              </div>
                          </form>
                    </section>
                </main>
            </div>
        )
    }
};