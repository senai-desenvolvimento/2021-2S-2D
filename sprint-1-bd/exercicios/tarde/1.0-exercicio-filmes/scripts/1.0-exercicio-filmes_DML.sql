USE CATALOGO_T;
GO 

INSERT INTO GENERO (nomeGenero)
VALUES ('A��O'), ('ROMANCE'), ('AVENTURA'), ('TERROR');
GO 

INSERT INTO FILME (tituloFilme, idGenero)
VALUES ('Rambo',1), ('Vingadores',1),
       ('Ghost',2), ('D�rio de uma paix�o',2),
	   ('HER', null), ('Homem-Aranha', null);
GO

-- OUTRA FORMA, COM OUTRO INSERT
--INSERT INTO FILME (tituloFilme)
--VALUES ('HER'), ('Homem-Aranha');
--GO
 

update FILME SET tituloFilme = 'RAMBO 2' 
WHERE idFilme =1 


DELETE FROM FILME 
WHERE idFilme in(2,3)


DELETE FROM GENERO
WHERE idGenero = 2 

--INSERT INTO GENERO (nomeGenero) VALUES ('teste');
--INSERT INTO GENERO (nomeGenero) VALUES ('')DROP TABLE FILME --')

UPDATE GENERO SET nomeGenero = 'Suspense' WHERE idGenero = 5 


INSERT INTO USUARIOS (email, senha, permissao)
VALUES ('lucas@email.com', '123','comum'),
       ('adm@email.com', '123','administrador');
GO