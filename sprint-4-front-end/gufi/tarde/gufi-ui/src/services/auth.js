// define a constante usuarioAutenticado para verificar se o usuário está logado
export const usuarioAutenticado = () => localStorage.getItem('usuario-login') !== null;

// define a constante parseJwt que retorn o payload do usuário logado convertido em JSON
export const parseJwt = () => {

    // define a variável base64 que recebe o payload do token do usuário logado
    let base64 = localStorage.getItem('usuario-login').split('.')[1];

    // converte o valor de base64 para string e em seguida para JSON
    return JSON.parse( window.atob(base64) );
};