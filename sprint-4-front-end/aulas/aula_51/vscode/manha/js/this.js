
// === igualdade escrita

//node = global
//navegador = window

//nesse caso o this representa o window que tem um objeto chamado document.
console.log(this.document === window.document)

console.log(this === window)


this.a = 20
console.log(window.a)




function thisNaoEstrito() {
   console.log(this)
}


function thisEstrito(){

'use strict'
console.log(this)

}


var Carro = new Object();
Carro.marca = "Fiat" //propriedade
Carro.localizaMarca = function(){ // metodo = propriedade que faz referencia em uma funcao.
         return this.marca
}


console.log(Carro.localizaMarca())






