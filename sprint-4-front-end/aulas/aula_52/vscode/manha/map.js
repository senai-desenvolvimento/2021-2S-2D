

//tenho uma colecao com 2 itens
const produtos =[
                 {
                     nome: "notebook",
                     preco: 2100

                 },
                 {

                    nome: "smartphone",
                    preco:400
                 }

           ]

//vamos considerar que o preco esta em dolar.
    
//map recebe como parametro o que chamamos de funcao callback
// entao internamente o map vai usar essa funcao para realizar a nossa regra de negocio

//p = produto como argumento.
// => arrow
// pegar o preco e multiplicar por 6
const precoEmReais = produtos.map(p => p.preco *6)

//console.log(precoEmReais) //novo retorno.
//console.log(produtos) // lista original

//

var numeros = [1,4,9];
const listaDobrada = numeros.map( function (num){
        return num * 2;
    } )

//console.log(listaDobrada)
//console.log(numeros)

//conversao de graus

var fahrenheit = [0,32,45,46,47,91,93,121]

const celcius = fahrenheit.map( function(item) {
  // (numero -32)*5/9
   return Math.round((item-32)*5/9)      
})

console.log(celcius);
console.log(fahrenheit);











