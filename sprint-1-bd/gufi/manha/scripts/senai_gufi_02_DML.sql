USE gufi_manha;
GO

--TIPO USUARIO
INSERT INTO tipoUsuario (tituloTipoUsuario)
VALUES					('Administrador'),
						('Comum');
GO

--INSTITUICAO
INSERT INTO instituicao (cnpj,nomeFantasia, endereco)
VALUES					('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539');
GO

--TIPO EVENTO
INSERT INTO tipoEvento (tituloTipoEvento)
VALUES				   ('C#'),
					   ('ReactJS'),
					   ('SQL');
GO

--SITUACAO
INSERT INTO situacao (descricao)
VALUES				 ('Aprovada'),
					 ('Recusada'),
					 ('Aguardando');
GO

--USUARIO
INSERT INTO usuario (idTipoUsuario, nomeUsuario, email, senha)
VALUES				(1, 'Administrador', 'adm@adm.com', 'senha123'),
					(2, 'Lucas', 'lucas@email.com', 'lucas123'),
					(2, 'Saulo', 'saulo@email.com', 'saulo123');
GO

--EVENTO
INSERT INTO evento (idTipoEvento, idInstituicao, nomeEvento, descricao, acessoLivre, dataEvento)
VALUES			   (1, 1, 'Orientação a Objetos', 'Conceitos sobre os pilares da programação orientada a objetos', 1, '18/08/2021 11:00'),
				   (2, 1, 'Ciclo de Vida', 'Como utilizar os ciclos de vida com a biblioteca ReactJs', 0, '19/08/2021 12:00');
GO

--PRESENCA
INSERT INTO presenca (idUsuario, idEvento, idSituacao)
VALUES				 (2, 2, 3),
					 (3, 1, 1)
GO



















