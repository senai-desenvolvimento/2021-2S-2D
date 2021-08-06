USE CATALOGO_T;
GO 

INSERT INTO GENERO (nomeGenero)
VALUES ('AÇÃO'), ('ROMANCE'), ('AVENTURA'), ('TERROR');
GO 

INSERT INTO FILME (tituloFilme, idGenero)
VALUES ('Rambo',1), ('Vingadores',1),
       ('Ghost',2), ('Dário de uma paixão',2),
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



