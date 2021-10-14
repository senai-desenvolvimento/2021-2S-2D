class Retangulo {
   
    constructor(altura, largura){

        this.altura = altura;
        this.largura = largura;
    } 
}

class Animal {

     constructor(nomequerecebeu){
         this.nome = nomequerecebeu;
         this.idade= 0;
     }    

    falar(){
          console.log( this.nome + ' emite um barulho');

    }
}

class Cachorro extends Animal{

     falar() {
         console.log(this.nome + ' latidos.')
     }
}

let cachorro = new Cachorro("dog")
cachorro.falar()




