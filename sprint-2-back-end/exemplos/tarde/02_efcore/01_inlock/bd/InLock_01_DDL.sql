-- Cria o banco de dados
CREATE DATABASE inLockGames_tarde;
GO

-- Define qual banco de dados será utilizado
USE inLockGames_tarde;
GO

-- Cria as tabelas
CREATE TABLE tipoUsuario(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,titulo				VARCHAR (255) UNIQUE NOT NULL
);
GO

CREATE TABLE usuario(
	idUsuario		INT PRIMARY KEY IDENTITY
	,email			VARCHAR (255) UNIQUE NOT NULL
	,senha			VARCHAR (255) NOT NULL
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario) NOT NULL
);
GO

CREATE TABLE estudio(
	idEstudio		INT PRIMARY KEY IDENTITY
	,nomeEstudio	VARCHAR (255) UNIQUE NOT NULL
);
GO

CREATE TABLE jogo(
	idJogo			INT PRIMARY KEY IDENTITY
	,nomeJogo		VARCHAR (255) UNIQUE NOT NULL
	,descricao		TEXT NOT NULL
	,dataLancamento	DATE NOT NULL
	,valor			DECIMAL (18,2) NOT NULL
	,idEstudio		INT FOREIGN KEY REFERENCES estudio(idEstudio)
);
GO