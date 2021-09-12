CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

CREATE TABLE tipoHabilidade(
	idTipoHabilidade TINYINT PRIMARY KEY IDENTITY,
	nomeTipoHabilidade VARCHAR(20) NOT NULL
);
GO


CREATE TABLE habilidade(
	idHabilidade TINYINT PRIMARY KEY IDENTITY,
	idTipoHabilidaDe TINYINT FOREIGN KEY REFERENCES tipoHabilidade(idTipoHabilidade),
	nomeHabilidade VARCHAR(50)
);
GO



CREATE TABLE classe(
	idClasse TINYINT PRIMARY KEY IDENTITY,
	habilidadePrimaria TINYINT FOREIGN KEY REFERENCES habilidade(idHabilidade),
	nomeClasse VARCHAR(20) NOT NULL
);
GO



CREATE TABLE personagem(
	idPersonagem TINYINT PRIMARY KEY IDENTITY,
	idClasse TINYINT FOREIGN KEY REFERENCES classe(idClasse),
	nomePersonagem VARCHAR(20) NOT NULL,
	capacidadeMaxVida TINYINT NOT NULL,
	capacidadeMaxMana TINYINT NOT NULL,
	dataAtualizacao Datetime NOT NULL,
	dataCriacao Datetime NOT NULL,
);
GO

