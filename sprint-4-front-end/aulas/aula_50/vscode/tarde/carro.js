
//novo objeto chamado carro.
var Carro = new Object();

Carro.marca = "Fiat";
Carro.modelo = "Uno";
Carro.cor = "Vermelho";
Carro.ligar = false;

Carro.partida = function(){
    Carro.ligar = true;
}

console.log(Carro);

Carro.partida();

console.log(Carro);






