const produtos =[
    {
        nome: "notebook",
        preco: 2100

    },
    {

       nome: "smartphone",
       preco:400
    },
    {
        nome: "outro",
        preco:1200
     },
     {
        nome: "outro 2",
        preco:1200
     }


]

//primeiro em reais.

const reais = produtos.map( p => p.preco * 6)
const soma_reais = reais.reduce((a,b) => a + b, 0)


const somareais = produtos.map( p => p.preco * 6).reduce((a,b) => a + b, 0)

console.log(reais);
console.log(soma_reais)
////console.log(somareais)



//a soma em reais.

