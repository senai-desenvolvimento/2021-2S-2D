
const numerosAleatorios = [ 36,99,37,63]

// item atual.
// index da posicao atual
//array que esta sendo interado.


const numeroMaior37 = numerosAleatorios.filter( (item,i) => item > 37 ) // se voltar TRUE.
//console.log(numeroMaior37)

//filter vai criar novo array analisando os itens que atende a funcao.
// a funcao SEMPRE tem que retonar um boolen, ou  seja, TRUE OU FALSE.
// TRUE = é add no novo array, e o False é ignorado.
// se todos forem FALSE, teremos um retorno de array vazio. [];


function MaiorQue37(value){

    // return value > 7   
    if(value > 37)
      return true
    else
      return false
}

var filtrado = [88,40,10,5,102,1].filter(MaiorQue37)

//console.log(filtrado);


//

var numeros_ = [1,2,3,4,5,6,7,8,9,10];

function buscaNumerosPares(value){
 
    console.log(value)

    if(value % 2 == 0)
       return true
    else
      return false 

}

var NumerosPares = numeros_.filter(buscaNumerosPares)

console.log(NumerosPares)



