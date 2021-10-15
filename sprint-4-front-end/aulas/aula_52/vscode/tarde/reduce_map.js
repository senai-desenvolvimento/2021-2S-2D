const  produtos = [
    {
        nome: "notebook",
        preco: 2100

    },{
        nome: "smartphone",
        preco: 400                    
    }

]

//primeiro vamos converter o preco para real (*6)

  //const valorReal =  produtos.map( p => p.preco * 6)

   //console.log(valorReal)

  //const SomaReal =  valorReal.reduce( (a,b) =>  a + b,0)

  //console.log(SomaReal)

  const valorReal =  produtos.map( p => p.preco * 6).reduce( (a,b) =>  a + b,0)
  console.log(valorReal)
 




//somar os dois valores que estao em real.




