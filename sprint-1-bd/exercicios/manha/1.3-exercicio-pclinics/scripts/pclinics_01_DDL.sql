CREATE DATABASE PClinics_M;
GO

USE PClinics_M;
GO

CREATE TABLE Clinica
(
    idClinica		INT PRIMARY KEY IDENTITY (1,1)
    ,razaoSocial    VARCHAR(200) NOT NULL UNIQUE
	,cnpj		    CHAR(14) NOT NULL UNIQUE
	,endereco	    VARCHAR(200) NOT NULL UNIQUE
);
GO

CREATE TABLE TiposPet
(
    idTipoPet	INT PRIMARY KEY IDENTITY
    ,descricao	VARCHAR(200) UNIQUE
);
GO

CREATE TABLE Raca
(
    idRaca		INT PRIMARY KEY IDENTITY
    ,descricao	VARCHAR(200) UNIQUE NOT NULL
    ,idTipoPet  INT FOREIGN KEY REFERENCES TiposPet (IdTipoPet)
);
GO

CREATE TABLE dono
(
	idDono		INT PRIMARY KEY IDENTITY
	,nome		VARCHAR(200) NOT NULL
);
GO

CREATE TABLE Pet
(
    idPet				INT PRIMARY KEY IDENTITY
    ,nome				VARCHAR(200)
    ,dataNascimento		DATE
	,idRaca				INT FOREIGN KEY REFERENCES Raca (IdRaca)
	,idDono				INT FOREIGN KEY REFERENCES Dono (IdDono)
);
GO

CREATE TABLE Veterinario
(
    idVeterinario   INT PRIMARY KEY IDENTITY
    ,nome			VARCHAR(200)
	,crmv			CHAR(6) UNIQUE
	,idClinica		INT FOREIGN KEY REFERENCES Clinica (idClinica)
);
GO

CREATE TABLE Atendimento
(
    idAtendimento		INT PRIMARY KEY IDENTITY
    ,descricao			VARCHAR(200)
	,dataAtendimento	DATETIME NOT NULL
	,idVeterinario		INT FOREIGN KEY REFERENCES Veterinario (IdVeterinario)
	,idPet				INT FOREIGN KEY REFERENCES Pet (IdPet)
);
GO