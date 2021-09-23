USE gufi_tarde;
GO 

--TIPO USUARIO
INSERT INTO tipoUsuario (tituloTipoUsuario)
VALUES                  ('Administrador'),
						('Comum');
GO

--USUARIO
INSERT INTO usuario (idTipoUsuario, nomeUsuario, email, senha)
VALUES              (1,'Administrador', 'adm@adm.com', 'adm12345');
GO

--comando para zerar os IDs da tabela.
--TRUNCATE TABLE usuario

-- USUARIO
INSERT INTO usuario (idTipoUsuario, nomeUsuario, email, senha)
VALUES              (2,'Lucas', 'lucas@email.com', 'LUCAS12345'),
                    (2,'Saulo', 'saulo@email.com','SAULO12345');
GO

-- INSTITUICAO
INSERT INTO instituicao ( CNPJ, nomeFantasia, endereco)
VALUES                  ('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539');
GO

-- TIPO EVENTO
INSERT INTO tipoEvento (tituloTipoEvento)
VALUES                 ('C#'),
					   ('ReactJS'),
					   ('SQL');
GO

--EVENTO
INSERT INTO evento (idTipoEvento, idInstituicao, nomeEvento, descricao, dataEvento, acessoLivre)
VALUES             (1, 1, 'Orientação a Objetos', 'Conceitos sobre os pilares da programação orientada a objetos', '18/08/2021 18:00', 1),
	               (2, 1, 'Ciclo de Vida', 'Como utilizar os ciclos de vida com a biblioteca ReactJs', '19/08/2021 10:00', 0);
GO

--Comando para retirar as linhas da tabela,CUIDADO se nao colocar o WHERE
--vai retirar TODAS as linhas.

--DELETE FROM evento

--SITUACAO
INSERT INTO situacao (descricao) 
VALUES               ('Aprovada'),
                     ('Recusada'), 
					 ('Aguardando');
GO

--PRESENCA
INSERT INTO presenca (idUsuario, idEvento, idSituacao)
VALUES               (2, 2, 3),
                     (3, 1, 1);
GO

--> nao existe usuario 4, vai dar erro na execucao.
-- INSERT INTO presenca (idUsuario, idEvento, idSituacao)
-- VALUES (4,3,1)