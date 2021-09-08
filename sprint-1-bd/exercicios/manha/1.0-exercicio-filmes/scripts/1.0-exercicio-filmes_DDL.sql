--Este é um comentário.

/*
	Este é um exemplo de 
	comentário em 
	várias linhas
*/

--atalho
--escrever depois crtl + k , crtk + c 

---COMANDOS DDL

--CREATE.

CREATE DATABASE CATALOGO_M;
GO

USE CATALOGO_M;
GO 

CREATE TABLE GENERO (
    idGenero TINYINT  PRIMARY KEY IDENTITY(1,1),
	nomeGenero VARCHAR(30)
);
GO

---COMANDO PARA ANALISAR A TABELA
-- ALT + F1 COM A TABELA SELECIONADA.

CREATE TABLE FILME (
   idFilme SMALLINT PRIMARY KEY IDENTITY(1,1),
   idGenero TINYINT FOREIGN KEY REFERENCES GENERO(idGenero),
   tituloFilme VARCHAR(70)
);
GO 

CREATE TABLE USUARIO(
   idUsuario  INT PRIMARY KEY IDENTITY,
   email VARCHAR(200) NOT NULL UNIQUE,
   senha VARCHAR(10) NOT NULL,
   permissao VARCHAR(50)
);
GO