

// === igualdade escrita.

console.log(this)

//nesse caso o this representa o window que tem um objeto chamado document.
console.log(this.document === window.document)// true


//confirmacao que o this é objeto global no caso do navegador = window.
console.log(this === window) // true

this.a = 20
console.log(window.a)


function thisNaoEstrito(){
    console.log(this)
}


// 'use strict' É UTILIZADO  para nao ter inconsistencias no codigo, como por exemplo
// colocar uma variavel no global.

function thisEstrito(){
        'use strict' 
        console.log(this)  //this nao existe objeto dentro da funcao.
}

thisNaoEstrito()
thisEstrito()


var Carro = new Object();
Carro.marca = "Fiat" // propriedade
Carro.localizaMarca = function(){
    return this.marca;
}


var Moto = new Object() 
Moto.marca = "Honda" // propriedade
Moto.localizaMarca = function(){
    return this.marca;
}

console.log(Carro.localizaMarca())
console.log(Moto.localizaMarca())




