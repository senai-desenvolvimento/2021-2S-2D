USE SENAI_HROADS_TARDE;
GO

INSERT INTO tipoHabilidade
VALUES ('Magia');
GO


INSERT INTO habilidade(nomeHabilidade, idTipoHabilidaDe)
VALUES ('Recuperar Vida', 3);
GO

INSERT INTO classe(nomeClasse, habilidadePrimaria)
VALUES ('Arcanista', null);
GO

INSERT INTO personagem(nomePersonagem, idClasse, capacidadeMaxVida, capacidadeMaxMana, dataAtualizacao, dataCriacao)
VALUES ('Lucas', 3, 40, 80, '10-08-2021', '17-03-2016');
GO

UPDATE personagem
SET nomePersonagem = 'Fer7'
WHERE nomePersonagem = 'Fer8';
GO


Select * from habilidade

select * from classe

