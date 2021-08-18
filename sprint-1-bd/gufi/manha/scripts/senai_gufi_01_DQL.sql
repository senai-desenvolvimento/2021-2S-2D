USE GUFI_MANHA;
GO 


--->LISTA TODOS OS TIPO DE USUARIO
   SELECT * FROM tipoUsuario 

--> LISTA TODOS OS USUARIOS

   SELECT * FROM usuario 


--> LISTA TODAS AS INSTUICOES

   SELECT * FROM instituicao 
   

--> LISTA TODOS OS TIPOS DE EVENTOS

    SELECT * FROM tipoEvento 


--> LISTA DE TODAS AS PRESENCAS

    SELECT * FROM presenca 


-->SELECIONAR OS DADOS DOS EVENTOS , DA INSTITUICAO E DOS TIPOS DE EVENTOS


SELECT  I.nomeFantasia, TE.tituloTipoEvento, E.nomeEvento, E.descricao, E.acessoLivre, E.dataEvento
FROM evento E
INNER JOIN tipoEvento te ON E.idTipoEvento = TE.idTipoEvento
INNER JOIN instituicao i ON E.idInstituicao = i.idInstituicao


-- Seleciona os dados dos usuários mostrando o tipo de usuário

SELECT U.nomeUsuario [Usuario] , TU.tituloTipoUsuario
FROM usuario U
INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario

-- Seleciona os dados dos eventos, da instituição, dos tipos de eventos 
--e dos usuários
-- e a situacao da presenca

SELECT u.nomeUsuario 'Usuário',
       e.nomeEvento 'Evento',
	   I.nomeFantasia 'Instituição',
       TE.tituloTipoEvento 'Tipo de Evento', 
	   S.descricao  'Situação',
	   TU.tituloTipoUsuario 'Tipo de Usuário'
FROM usuario  U
INNER JOIN presenca P ON U.idUsuario = P.idUsuario
INNER JOIN evento E ON P.idEvento = E.idEvento
INNER JOIN tipoEvento TE ON E.idTipoEvento = TE.idTipoEvento
INNER JOIN situacao S ON P.idSituacao = S.idSituacao
INNER JOIN instituicao I ON  E.idInstituicao = I.idInstituicao
INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario


-- Busca um usuário através do seu e-mail e senha

--WHERE

SELECT U.nomeUsuario Usuario, 
       TU.tituloTipoUsuario [Tipo de Usuario],
	   U.email Email,
	   U.senha Senha  
FROM usuario u
JOIN tipoUsuario tu on u.idTipoUsuario = tu.idTipoUsuario
WHERE email = 'LUCAS@LUCAS.COM'
AND senha = 'lucas123';




