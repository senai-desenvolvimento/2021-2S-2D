USE gufi_tarde;
GO

-- Lista todos os tipos de usuários
   SELECT * FROM tipoUsuario 

-- Lista todos os usuários
   SELECT * FROM usuario 

-- Lista todas as instituições
   SELECT * FROM instituicao 

-- Lista todos os tipos de eventos
   SELECT * FROM tipoEvento

-- Lista todos os eventos 
   SELECT * FROM evento

-- Lista todas as presenças
   SELECT * FROM presenca 

-- Seleciona os dados dos usuários mostrando o tipo de usuário
   SELECT U.idUsuario as ID,
          U.nomeUsuario [USUARIO NOME], 
		  --T.idTipoUsuario 'Tipo de Usuário', -- COLUNA COMENTADA.
		  T.tituloTipoUsuario titulo
   FROM usuario U
   INNER JOIN tipoUsuario T ON U.idTipoUsuario = T.idTipoUsuario
   	  
-- Seleciona os dados dos eventos, da instituição e dos tipos de eventos
   SELECT E.nomeEvento Evento,
          I.nomeFantasia Instituição,
	      TE.tituloTipoEvento [Tipo do Evento]
   FROM evento E
   INNER JOIN tipoEvento TE ON E.idTipoEvento = TE.idTipoEvento
   INNER JOIN instituicao I ON E.idInstituicao = I.idInstituicao
   	  
-- Seleciona os dados dos eventos, da instituição, 
-- dos tipos de eventos e dos usuários
-- e a situacao da presenca
   SELECT U.nomeUsuario Usuário,
          TU.tituloTipoUsuario [Tipo de Usuário],
          U.email [Email do Usuário],
		  E.nomeEvento [Nome do Evento],
		  E.dataEvento,		 
		  convert(varchar(20),E.dataEvento,106) [Data do Evento], --TRATADO.
		  TE.tituloTipoEvento [Tipo do Evento],
		  I.nomeFantasia Instituição,
		  S.descricao Situação,
		  E.acessoLivre
   FROM usuario U
   INNER JOIN presenca P ON (U.idUsuario = P.idUsuario)
   INNER JOIN situacao S ON (P.idUsuario = S.idSituacao)
   INNER JOIN evento E ON (P.idEvento = E.idEvento)
   INNER JOIN tipoEvento TE ON (E.idTipoEvento = TE.idTipoEvento)
   JOIN instituicao I ON (E.idInstituicao = I.idInstituicao)
   INNER JOIN tipoUsuario TU ON (U.idTipoUsuario = TU.idTipoUsuario) 

-- Busca um usuário através do seu e-mail e senha
   SELECT nomeUsuario, email, senha 
   FROM usuario 
   WHERE email = 'adm@adm.com'
   AND senha = 'adm12345';