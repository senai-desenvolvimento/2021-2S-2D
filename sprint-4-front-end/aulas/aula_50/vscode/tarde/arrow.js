
const soma = function(a,b){
    return a+ b;
}

function soma(a,b){
     return a+b;
}


//funcao arrow com return explicito.
const soma = (a,b) => {
    return a+ b;
}

//funcao arrow com return implicito
const soma = (a,b) => a + b;


function imprimeTexto(texto)
{
    return texto
}


const imprimeTexto = texto => texto

console.log(imprimeTexto("teste arrow"))


//funcao arrow sem parametro
ola = () => 'Olá'

//funcao arrow com um parametro, que pode ser ignorado
ola = _ => 'Olá'
// _  (underscore) não é ausencia de parametro, é apenas ignoravel.












