
//queremos saber a soma de todos os precos da lista.
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

//reduce pode receber uma funcao callback como parametro.

//reduce ele tem 2 parametros.


//produtos.reduce(a,b)

//a  = nosso acumulador.
// b é o tiem que eu quero processar, ou seja, o valor atual.


//nesse caso o a (acumulador) vai iniciar como 0.

//produtos.reduce((a,b) =>      ,0)


//sintaxe
// array.reduce( acumulador, valoratua[ index []], valorinicial)


 const total = produtos.reduce( (a,b) => a + b.preco, 0)

 //console.log(total); 


//somatoria

var valores = [1.5, 2,4,10]

var somatoria = valores.reduce( function(total, item){

     //regra. 
    console.log(total)
    return total + item
}, 0 )


//console.log(somatoria)

///media (soma de todos os itens, dividio pela quantidade.)

var valores = [1.5,2,4,10]

//1.5  [0] posicao
// 2 [1] posicao
// 4 [2] posicao
// 10 [3]~posicao

//4 itens


var media = valores.reduce( (total, item, indice, array) => {

    
    total += item
    // total = total + item.

   // console.log("log do total: " + total)
   // console.log("log do indice: " + indice)

    //quando o indice bater com o total, (4-1 = 3), entao retorna a media.
    
  
    if(indice == array.length-1){
        return total/ array.length
    } 
    return total 
},0)


console.log(media)









 










