console.log("10" / 2)       
// a conversão é feita e retorna 5

console.log("10" + 2)       
// a concatenação é feita e retorna 102

console.log("10,2" / 2)     
// a conversão não é feita e retorna NaN (not a number)

console.log(0.1 + 0.7)      
// a soma é feita mas com imprecisão, retornando 0.79


Number(null)                
// 0

null == 0                   
// false

null < 1                    
// true

typeof(NaN)                 
// number


var nome = 'saulo'  // string
var idade = 29      // number
var semDefinicao    // undefined
var nula = null     // objeto (!?!?)

let x = 3           // number    
let jogo = 'Poker'  // string
let qualquer        // undefined

const nota = 0              // number
const sobrenome = 'santos'  // string
const naoDefinida           // undefined

if (true) {
    var escopoBlocoGlobal = 'Possuo valor fora do escopo de bloco';
}

console.log(escopoBlocoGlobal);     // retorna o valor da variável

if (true) {
    let escopoBlocoLocal = 'Não possuo definição fora do escopo de bloco';
}

console.log(escopoBlocoLocal);      // retorna ReferenceError: escopoBlocoLocal is not defined
                                    // obs.: no JavaScript o uso do ; é opcional

function minhaFuncao() {
    var escopoFuncaoGlobal = 'Não possuo valor fora do escopo de função';
    let escopoFuncaoLocal = 'Não possuo valor fora do escopo de função';
    return escopoFuncaoGlobal + ' e ' + escopoFuncaoLocal;
}

console.log(minhaFuncao());         // retorna o valor das variáveis concatenadas
console.log(escopoFuncaoGlobal);    // retorna ReferenceError: escopoFuncaoGlobal is not defined
console.log(escopoFuncaoLocal);     // retorna ReferenceError: escopoFuncaoLocal is not defined


var fruta = 'banana';
console.log(fruta);
// o resultado é 'banana'

console.log(fruta);
var fruta = 'banana';
// o resultado é undefined, ou seja, a declaração da variável foi elevada

console.log(fruta);
var fruta = 'banana';
console.log(fruta);
// o resultado é undefined e banana
// pois no primeiro console log a variável foi definida sem estar atribuída e
// no segundo já estava com atribuição


let fruta = 'banana';
console.log(fruta);
// o resultado é 'banana'

console.log(fruta);
let fruta = 'banana';
// o resultado é ReferenceError:
// cannot acess 'fruta' before initialization

console.log(fruta);
let fruta = 'banana';
console.log(fruta);
// o resultado é ReferenceError:
// cannot acess 'fruta' before initialization


// =    (atribuição)
// ==   (igualdade)
// ===  (igualdade estrita)
// &&   (and)
// ||   (or)
// !    (not)

x = y           // atribui o valor de y a x
var var1 = 3    // atribui o valor 3 à variável var1
3 == var1       // true
"3" == var1     // true
3 == '3'        // true
3 === var1      // true
3 === '3'       // false

+ 3             // retorna 3
+ '3'           // retorna 3
+ 'saulo'       // retorna NaN
'san' + 'tos'   // retorna santos
3 + '3'         // retorna 33
'3' + 3         // retorna 33
var x = 3       // declaração de variável com atribuição de valor
-x              // retorna -3
x               // retorna 3