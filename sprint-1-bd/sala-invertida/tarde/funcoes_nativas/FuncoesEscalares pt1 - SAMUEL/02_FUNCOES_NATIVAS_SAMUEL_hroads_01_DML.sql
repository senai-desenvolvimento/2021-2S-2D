/* 3. Inserir os registros conforme descrição no próprio texto 
(classes, habilidades, tipos de habilidades e personagens); */

USE FUNCOES_NATIVAS_SAMUEL;
GO

INSERT INTO CLASSE (nomeClasse, ptsVida, ptsMana)
VALUES ('Barbaro', 100, 80),('Monge', 70, 100),('Arcanista', 75, 60),
('Necromante', 60, 90), ('Feiticeiro', 65, 85),('Cruzado', 90, 70),('Caçadora de Demônios', 85, 90);
GO

INSERT INTO TIPO_HABILIDADE (nomeTipoHabilidade)
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia')
GO

INSERT INTO HABILIDADE (idTipoHabilidade, nomeHabilidade)
VALUES (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida')
GO

INSERT INTO PERSONAGEM (idClasse, nomePersonagem, dataCriacao, dataAtualizacao)
VALUES (1, 'DeuBug', '05/02/2021','10/08/2021'), (2, 'BitBug','01/01/2020','10/08/2021'), 
(3, 'Fer8','03/05/2020','10/08/2021'),(4, 'BDD','29/07/2021','10/08/2021')
GO

INSERT INTO CLASSE_HABILIDADE (idHabilidade, idClasse)
VALUES (1,1),(2,1),(2,2),(3,2),(NULL,3),(NULL,4),(3,5),(2,6),(1,7)
GO

INSERT INTO PLAYER(idPersonagem, nomePlayer)
VALUES (1, 'Samuel'), (2, 'Erick'), (3, 'Erick'), (4, 'Samuel')
GO

--4. Atualizar o nome do personagem Fer8 para Fer7;
UPDATE PERSONAGEM
SET nomePersonagem = 'Fer7'
WHERE PERSONAGEM.idPersonagem = 3;
GO

--5. Atualizar o nome da classe de Necromante para Necromancer;
UPDATE CLASSE
SET nomeClasse = 'Necromancer'
WHERE CLASSE.idClasse = 4;
GO


