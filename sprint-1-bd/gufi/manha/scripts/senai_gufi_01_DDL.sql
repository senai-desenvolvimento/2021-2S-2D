CREATE DATABASE gufi_manha;
GO

USE gufi_manha;
GO

-- TIPO USUARIO
CREATE TABLE tipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(30) UNIQUE NOT NULL
);
GO

-- TIPO EVENTO
CREATE TABLE tipoEvento(
	idTipoEvento INT PRIMARY KEY IDENTITY,
	tituloTipoEvento VARCHAR(50) UNIQUE NOT NULL
);
GO

-- INSTITUICAO
CREATE TABLE instituicao(
	idInstituicao INT PRIMARY KEY IDENTITY,
	cnpj CHAR(14) UNIQUE NOT NULL,
	nomeFantasia VARCHAR(100) NOT NULL UNIQUE,
	endereco VARCHAR(250) UNIQUE NOT NULL
);
GO

-- SITUACAO
CREATE TABLE situacao (
	idSituacao INT PRIMARY KEY IDENTITY,
	descricao VARCHAR(50)
);
GO

-- USUARIO
CREATE TABLE usuario (
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nomeUsuario VARCHAR(50) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	senha VARCHAR(10) NOT NULL
);
GO

-- EVENTO
CREATE TABLE evento(
	idEvento INT PRIMARY KEY IDENTITY,
	idTipoEvento INT FOREIGN KEY REFERENCES tipoEvento(idTipoEvento),
	idInstituicao INT FOREIGN KEY REFERENCES instituicao(idInstituicao),
	nomeEvento VARCHAR(100) NOT NULL,
	descricao VARCHAR(500) NOT NULL,
	acessoLivre BIT DEFAULT (1),
	dataEvento DATETIME NOT NULL
);
GO

-- PRESENCA
CREATE TABLE presenca(
	idPresenca INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idEvento INT FOREIGN KEY REFERENCES evento(idEvento),
	idSituacao INT FOREIGN KEY REFERENCES situacao(idSituacao) DEFAULT (3)
);
GO

-- IMAGEM USUARIO
CREATE TABLE imagemUsuario (
	id INT PRIMARY KEY IDENTITY(1,1),
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
	IDENTITY = Define que o campo será auto-incremento e unico e (1,1) 
			   inicia do 1 e vai de 1 em 1.
	NOT NULL = Não pode ser nulo, ou seja, é obrigatorio.
	UNIQUE = Campo é UNIQUE , ou seja , não se repete.
	DEFAULT = Defineum valor padrão, caso nenhum seja informado.
	GO = Pausa a leitura e executa o bloco de codigo acima.
*/