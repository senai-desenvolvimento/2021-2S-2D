import {Component} from "react";

class Titulo extends Component{

   render(){

        return(
            <h2 className="conteudoPrincipal-cadastro-titulo">{this.props.titulosecao}</h2>                   

        )
   }
}

export default Titulo;

