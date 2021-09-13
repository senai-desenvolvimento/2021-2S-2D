-- Define qual banco de dados será utilizado
USE inLockGames_tarde;
GO

-- Insere os tipos de usuário
INSERT INTO tipoUsuario(titulo)
VALUES					('Administrador')
					   ,('Cliente');
GO

-- Insere os usuários
INSERT INTO usuario(email, senha, idTipoUsuario)
VALUES				('admin@admin.com','admin',1)
				   ,('cliente@cliente.com','cliente',2);
GO

-- Insere os estúdios
INSERT INTO estudio(nomeEstudio)
VALUES				('Blizzard')
				   ,('Rockstar Studios')
				   ,('Square Enix');
GO

-- Insere os jogos
INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','2012-05-15','99.00',1)
				,('Red Dead Redemption II','jogo eletrônico de ação-aventura western','2018-10-26','120.00',2);
GO