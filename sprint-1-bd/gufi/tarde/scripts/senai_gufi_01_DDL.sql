CREATE DATABASE gufi_tarde;
GO 

USE gufi_tarde;
GO

--- TIPOUSUARIO
CREATE TABLE tipoUsuario (
	idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(50) UNIQUE NOT NULL
);
GO

-- TIPO EVENTO
CREATE TABLE tipoEvento(
	idTipoEvento INT PRIMARY KEY IDENTITY,
	tituloTipoEvento VARCHAR(100) UNIQUE NOT  NULL
);
GO

-- SITUACAO
CREATE TABLE situacao (
	idSituacao TINYINT PRIMARY KEY IDENTITY,
	descricao VARCHAR(25) NOT NULL UNIQUE
);
GO

-- INSTITUIÇÃO
CREATE TABLE instituicao (
	idInstituicao SMALLINT PRIMARY KEY IDENTITY,
	CNPJ CHAR(18) UNIQUE NOT NULL,
	nomeFantasia VARCHAR(100) NOT NULL,
	endereco VARCHAR(150) UNIQUE NOT NULL
);
GO

-- USUARIO
CREATE TABLE usuario (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario SMALLINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(100) NOT NULL,
	email VARCHAR(256) UNIQUE NOT NULL,
	senha VARCHAR(10) NOT NULL CHECK( len(senha) >= 8)  -->REGRA PARA COLOCAR APENAS 8. LEN PEGA O TAMANHO.
);
GO

-- EVENTO
CREATE TABLE evento(
	idEvento INT PRIMARY KEY IDENTITY,
	idTipoEvento INT FOREIGN KEY REFERENCES tipoEvento (idTipoEvento),
	idInstituicao SMALLINT FOREIGN KEY REFERENCES instituicao(idInstituicao),
	nomeEvento VARCHAR(50) NOT NULL,
	descricao VARCHAR(300) NOT NULL,
	dataEvento DATETIME NOT NULL,
	acessoLivre BIT DEFAULT (1)
);
GO

-- PRESENCA
CREATE TABLE presenca (
	idPresenca INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario ( idUsuario),
	idEvento INT FOREIGN KEY REFERENCES evento(idEvento),
	idSituacao TINYINT FOREIGN KEY REFERENCES situacao(idSituacao)
);
GO

--IMAGEM USUARIO
CREATE TABLE imagemUsuario (
	id INT PRIMARY KEY identity(1,1),
	idUsuario INT NOT NULL UNIQUE FOREIGN KEY REFERENCES usuario(idUsuario),
	binario VARBINARY(MAX) NOT NULL,
	mimeType VARCHAR(30) NOT NULL,
	nomeArquivo VARCHAR(250) NOT NULL,
	data_inclusao DATETIME DEFAULT GETDATE() NULL
);
GO

/*
	RESUMO
	PRIMARY KEY = CHAVE PRIMARIA
	FOREIGN KEY = CHAVE ESTRANGEIRA
	IDENTITY = Define que o campo será auto-incrementado e único.
	NOT NULL = Define que não pode ser nulo, ou seja, obrigatório.
	UNIQUE = Define que o valor do campo é unico, ou seja, não repete.
	DEFAULT = Define um valor padrão, caso nenhum seja informado.
	GO = Pausa a leitura e executa o bloco de código acima.
*/