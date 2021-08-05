USE catalogo;
GO 

INSERT INTO GENERO (nomeGenero)
VALUES ('AÇÃO'), ('ROMANCE');
GO 

INSERT INTO FILME (tituloFilme,idGenero)
VALUES ('Rambo',1), ('Vingadores',1),
       ('GHOST',3), ('DIARIO DE UMA PAIXAO',3);
GO
 

update FILME SET tituloFilme = 'RAMBO 2' 
WHERE idFilme =1 


DELETE FROM FILME 
WHERE idFilme in(2,3)


DELETE FROM GENERO
WHERE idGenero = 2 



