CREATE DATABASE EXEMPLO_NORMAS_CERTO
GO

USE EXEMPLO_NORMAS_CERTO
GO

CREATE TABLE SETOR(
	idSetor INT PRIMARY KEY IDENTITY (1,1),
	nomeSetor VARCHAR(25) UNIQUE NOT NULL
);
GO

CREATE TABLE CARGO(
	idCargo INT PRIMARY KEY IDENTITY (1,1),
	nomeCargo VARCHAR(30)
);
GO

CREATE TABLE CARGOFUNCIONARIO(
	idCargoFuncionario INT PRIMARY KEY IDENTITY (1,1),
	idSetor INT FOREIGN KEY REFERENCES SETOR(idSetor),
	idCargo INT FOREIGN KEY REFERENCES CARGO(idCargo)
);
GO

CREATE TABLE FUNCIONARIO(
	idFuncionario INT PRIMARY KEY IDENTITY (1,1),
	IdCargoFuncionario INT FOREIGN KEY REFERENCES CARGOFUNCIONARIO(idCargoFuncionario) NOT NULL,
	nomeFuncionario VARCHAR(50) NOT NULL,
	CPF VARCHAR(11) UNIQUE NOT NULL,
	salario SMALLMONEY NOT NULL,
	dataContratacao DATE NOT NULL
);
GO

CREATE TABLE EMAIL(
	idEmail INT PRIMARY KEY IDENTITY (1,1),
	idFuncionario INT FOREIGN KEY REFERENCES FUNCIONARIO(idFuncionario) NOT NULL,
	endEmail VARCHAR(254) NOT NULL
);
GO

CREATE TABLE TELEFONE(
	idTelefone INT PRIMARY KEY IDENTITY (1,1),
	idFuncionario INT FOREIGN KEY REFERENCES FUNCIONARIO(idFuncionario) NOT NULL,
	numTelefone VARCHAR (11)
);
GO