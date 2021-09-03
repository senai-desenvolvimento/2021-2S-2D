--COMENTARIO DE UMA LINHA

	/*

	COMENTARIO
	DE
	VARIAS LINHAS

	*/

---CRIA UM BANCO DE DADOS CHAMADO CATALOGO.
CREATE DATABASE CATALOGO_T;
GO 

--define o banco de dados que sera utilizado
USE CATALOGO_T;
GO

CREATE TABLE GENERO (
  idGenero TINYINT PRIMARY KEY IDENTITY(1,1),
  nomeGenero VARCHAR(20) NOT NULL
);
GO

--ALTER TABLE  GENERO
--DROP COLUMN nomeGenero

ALTER TABLE GENERO
ADD nomeGenero VARCHAR(20) NOT NULL 

CREATE TABLE FILME(
  idFilme SMALLINT PRIMARY KEY IDENTITY(1,1),
  idGenero TINYINT FOREIGN KEY REFERENCES GENERO(idGenero),
  tituloFilme VARCHAR(50) NOT NULL
);


CREATE TABLE USUARIOS(
   
   idUsuario int primary key identity,
   email varchar(100) not null unique,
   senha varchar(10) not null,
   permissao varchar(30) not null
);
GO


