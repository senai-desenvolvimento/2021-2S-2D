
const numeros = [36,99,37,63]

//filter


// item autal
//index posicao do item
// array que esta sendo interado.

// a funcao SEMPRE tem que retornar um boolen. se for true add na lista,
// senao ele vai para o proximo item.


const numeroMaiorQue37 = numeros.filter( (item) => item > 37 ) //se voltar true.

//console.log(numeroMaiorQue37)



function MaiorQue37 (value){
 return value > 7
}

var filtrado = [88,40,10,5,102,1].filter(MaiorQue37)

//console.log(filtrado)


var numero_1_a_10 = [1,2,3,4,5,6,7,8,9,10];

function buscaNumeroPar(value){

// % resto da divisao
// se for 0 é par.
   if(value % 2 == 0){
       return true;

   }else{
       return false;
   }    
}

var numeroPar = numero_1_a_10.filter(buscaNumeroPar)

console.log(numeroPar)























