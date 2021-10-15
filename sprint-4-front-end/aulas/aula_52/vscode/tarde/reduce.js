// nossa lista temos que devolver a soma de todos os produtos.

const  produtos = [
    {
        nome: "notebook",
        preco: 2100

    },{
        nome: "smartphone",
        preco: 400                    
    }

]

//a = nosso acumulador
//b = é o que eu quero processar, possui o valor atual.

//produtos.reduce( (a,b)  )


//produtos.reduce( (a,b) =>    ,0)

//sintaxe
//array.reduce( acumulador, valoratual[], valor inicial.)

const total = produtos.reduce( (a,b) => a + b.preco ,0)

//console.log(total) //2500



var valores = [1.5,2,4,10]

var somatoria = valores.reduce( function(total, item){
  
    //console.log("o valor do total nesse momento: " + total )
   // console.log("o valor do item nesse momento: " + item )
    return total + item

},0)

//console.log(somatoria)

//media

var notas = [1.5,2,4,10]
//formula para consular media.
// somar todos, e dividir o total pela quantidade de elementos.
 var total_divisao = 0
var media = notas.reduce(  (total, item,index,array) => {  

     //total = total +  item
     total += item
     
     //paramos no ultimo no item.
     if(index === array.length -1)
       return total / array.length
    
    return total

},0)

console.log(media)






















