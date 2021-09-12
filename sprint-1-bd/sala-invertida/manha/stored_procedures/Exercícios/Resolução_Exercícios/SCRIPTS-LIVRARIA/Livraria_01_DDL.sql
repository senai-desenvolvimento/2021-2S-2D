CREATE DATABASE LIVRARIA;
GO

USE LIVRARIA;
GO

CREATE TABLE Livraria (
idLivraria SMALLINT PRIMARY KEY IDENTITY (1,1),
nomeLivraria VARCHAR(20)
);
GO

CREATE TABLE Categoria(
idCategoria SMALLINT PRIMARY KEY IDENTITY(1,1),
nomeCategoria  VARCHAR(20)
);
GO


CREATE TABLE Livro (
idLivro SMALLINT PRIMARY KEY IDENTITY(1,1),
idLivraria SMALLINT FOREIGN KEY REFERENCES Livraria(idLivraria),
idCategoria SMALLINT FOREIGN KEY REFERENCES Categoria(idCategoria),
nomeLivro VARCHAR (45) NOT NULL,
autor VARCHAR (50),
precoLivro SMALLINT
);
GO

CREATE TABLE Livrara_Livro (
id  SMALLINT PRIMARY KEY IDENTITY(1,1),
idLivro SMALLINT FOREIGN KEY REFERENCES Livro(idLivro),
idLivraria SMALLINT FOREIGN KEY REFERENCES Livraria(idLivraria),
idCategoria SMALLINT FOREIGN KEY REFERENCES Categoria(idCategoria)
);
GO