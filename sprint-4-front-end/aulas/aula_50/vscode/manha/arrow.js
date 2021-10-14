
const soma = function soma(a,b){
return a + b;
}

//funcao arrow com return explicito
const soma = (a,b) => {
  return a+ b;
}

//funcao arrow com return implicito
const soma = (a,b) => a + b 


function imprimetexto(texto){
    return texto
}

const imprimetexto = texto => texto 

console.log(imprimetexto("teste arrow"))


//funcao arrow sem parametro
let ola = () => 'Olá' 

//funcao arrow com apenas um parametro mas que pode ser ignorado.

ola = _ => 'Olá'
// _ não é ausencia de parametro, é um parametro ignorável.






