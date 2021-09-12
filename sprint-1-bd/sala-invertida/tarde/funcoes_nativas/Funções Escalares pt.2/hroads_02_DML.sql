CREATE DATABASE SENAI_HROADS_TARDE;
GO

USE SENAI_HROADS_TARDE;
GO

INSERT INTO tipoHabilidade (nomeTipo)
VALUES ('Ataque'),('Defesa'),('Cura'),('Magia');
GO

INSERT INTO habilidade (idTipo, nomeHabilidade)
VALUES (1,'Lança Mortal'),(2,'Escudo Supremo'),(3,'Recuperar Vida');
GO

INSERT INTO classe (nomeClasse)
VALUES ('Bárbaro'),('Cruzado'),('Caçadora de Demônios'),('Monge'),('Necromante'),('Feiticeiro'),('Arcanista');
GO

SELECT * FROM classe;

UPDATE classe set nomeClasse = 'Necromancer'
WHERE idClasse = 5

INSERT INTO classe_habilidade (idClasse, idHabilidade)
VALUES (1,1),(1,2),(2,2),(3,1),(4,3),(4,2),(5,NULL),(6,3),(7,NULL);
GO

INSERT INTO personagem (idClasse, nomePersonagem, vidaMax, manaMax, dataCriacao, dataAtualizacao)
VALUES (1,'DeuBug',100,80,'18/01/2019', GETDATE()),(4,'BitBug',70,100,'17/03/2016',GETDATE()),
(7,'Fer8',75,60,'18/03/2018',GETDATE());

SELECT * FROM personagem;

UPDATE personagem set nomePersonagem = 'Fer7'
WHERE idPersonagem = 3

INSERT INTO exemplo (nomeExemplo, dataCriação, dataAtualização)
VALUES ('Edson','24/04/2005',GETDATE()), ('Joao','22/02/2004',GETDATE());

SELECT * FROM EXEMPLO


SELECT UPPER(nomeExemplo) FROM EXEMPLO


