import React from 'react';
import './App.css';

// Define um componente funcional DataFormatada que retorna o subtítulo com o valor da data e hora formatado
function DataFormatada(props) {
  return <h2>Horário Atual: {props.date.toLocaleTimeString()}</h2>
}

// Componente de classe
// Define a classe Clock que será chamada dentro do App
class Clock extends React.Component {
  constructor(props){
    super(props);
    this.state = {
      // Define a propriedade date do state com o valor inicial como a data e hora daquele momento
      date : new Date()
      // 1 - 19/10/2021 08:54:33
      // 2 - 19/10/2021 08:54:34
      // 3 - 19/10/2021 08:54:35
    }
  }

  // Ciclo de vida que ocorre quando Clock é inserido na DOM (ou seja, ciclo de vida do nascimento)
  componentDidMount(){
    this.timerID = setInterval( () => {
      this.thick()
    }, 1000 );

    // Exibe no console o ID de cada relógio
    console.log('Eu sou o relógio ' + this.timerID);
  }

  // Ciclo de vida que ocorre quando Clock é removido da DOM (ou seja, ciclo de vida da morte)
  // Quando isso acontece, a função clearInterval() limpa o relógio criado pela setInterval
  componentWillUnmount(){
    clearInterval(this.timerID);
  }

  // Atualiza o state date com a data e hora deste momento, ou seja, quando a função thick() for invocada
  thick(){
    this.setState({
      date : new Date()
    })
  }

  // Renderiza na tela o conteúdo do return
  render(){
    return(
      <div>
        <h1>Relógio</h1>
        <DataFormatada date={this.state.date} />
      </div>
    )
  }
}

// Componente funcional
function App() {
  return (
    // JSX
    <div className="App">
      <header className="App-header">
        {/* Faz a chamada de dois componentes Clock */}
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

// Declara que o componente App pode ser utilizado fora deste escopo
export default App;
