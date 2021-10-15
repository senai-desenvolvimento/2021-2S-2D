//colecao com 2 itens

const  produtos = [
                {
                    nome: "notebook",
                    preco: 2100

                },{
                    nome: "smartphone",
                    preco: 400                    
                }

]

//p = vai receber o produto como argumento.
// => arrow
// de cada item pegamos o preco e multiplacamos por 6.

const precoEmReais = produtos.map( p => p.preco * 6)

//map recebe como parametro o que chamamos de funcao callback.
//entao internamente o map vai utilizar essa funcao para realizar a nossa regra de 
//negocio.

//console.log(precoEmReais); 
//console.log(produtos)


var numeros = [1,4,9];

var listaDobrada = numeros.map( function(item) {
  // console.log(item)
   return item * 2;
} )

//console.log(listaDobrada)


/// 

var fahrenheit = [0,32,45,46,47,91,93,121]

var celcius = fahrenheit.map( function(item){   
    // (item-32) * 5/9
    return Math.round((item-32)*5/9)
})

console.log(fahrenheit)
console.log(celcius)

