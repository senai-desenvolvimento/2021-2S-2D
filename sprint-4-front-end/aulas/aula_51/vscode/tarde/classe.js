class Retangulo {
    constructor(altura, largura){
        this.altura = altura
        this.largura = largura
    }
}

class Animal{
  
    constructor(nome){
        this.nome = nome;
    }

    falar(){
        console.log(this.nome + ' emite um barulho');
    }
}
class Cachorro extends Animal{

     falar(){
        console.log( this.nome + ' latidos.');
    }
}

let cachorro = new  Cachorro('Dog');
cachorro.falar();


