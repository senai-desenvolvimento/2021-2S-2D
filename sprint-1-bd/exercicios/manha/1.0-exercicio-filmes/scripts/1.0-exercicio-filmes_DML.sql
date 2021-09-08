USE CATALOGO_M;
GO

INSERT INTO GENERO (nomeGenero)
VALUES ('AÇÃO'), ('COMÉDIA');
GO

INSERT INTO GENERO (nomeGenero)
VALUES ('ROMANCE'), ('TERROR');
GO



INSERT INTO FILME (idGenero,tituloFilme)
VALUES (1,'RAMBO'), (1,'VINGADORES'),
       (3,'GHOST'), (3,'DIARIO DE UMA PAIXAO');
GO

INSERT INTO FILME (tituloFilme)
VALUES ('HER'), ('HOMEM-ARANHA');
GO


UPDATE FILME  
SET tituloFilme = 'GENTE GRANDE'
WHERE idFilme = 6; 
GO

--DELETE FROM GENERO 
--WHERE idGenero = 2;
--GO

--DELETE FROM GENERO 
--WHERE idGenero IN(2,1);
--GO

--INSERT INTO GENERO (nomeGenero)
--VALUES			   ('teste2')
--GO

--INSERT INTO GENERO (nomeGenero)
--VALUES			 (' ')DROP TABLE Filme -- '),;
--GO

--DELETE FROM GENERO WHERE idGenero = 8;

UPDATE GENERO  
SET nomeGenero = 'Suspense'
WHERE idGenero = 5; 
GO

INSERT INTO USUARIO (email, senha, permissao)
VALUES				('saulo@email.com','123','administrador'),
					('lucas@email.com','123','comum');
GO
