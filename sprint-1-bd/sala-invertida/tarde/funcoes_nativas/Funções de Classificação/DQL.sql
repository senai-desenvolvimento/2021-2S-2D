USE SENAI_HROADS_TARDE;
GO

SELECT * FROM personagem;
GO

SELECT * FROM classe;
GO

SELECT * FROM personagem;
GO

SELECT * FROM tipoHabilidade;
GO

SELECT * FROM habilidade;
GO

SELECT nomeClasse Classe
From classe;
GO

SELECT nomePersonagem Nome, nomeClasse as Classe, capacidadeMaxVida as 'Vida Máxima', capacidadeMaxMana as 'Mana Máxima',
	ROW_NUMBER() OVER(ORDER BY capacidadeMaxVida ) as 'ROW_NUMBER',
	RANK() OVER(ORDER BY capacidadeMaxVida) as 'RANK',
	DENSE_RANK() OVER(ORDER BY capacidadeMaxVida) as 'DENSE_RANK'
FROM personagem
INNER JOIN classe
ON personagem.idClasse = classe.idClasse
ORDER BY capacidadeMaxVida ;
GO

SELECT
	COUNT(*) as 'Quantidade de habilidade cadastradas'
FROM habilidade

SELECT idHabilidade 
FROM habilidade 
ORDER BY idHabilidade ASC;
GO

SELECT * FROM tipoHabilidade;
GO

SELECT nomeHabilidade, nomeTipoHabilidade
FROM habilidade
LEFT JOIN tipoHabilidade
ON habilidade.idHabilidade = tipoHabilidade.idTipoHabilidade


SELECT nomePersonagem, nomeclasse
FROM personagem
LEFT JOIN classe
ON personagem.idClasse = classe.idClasse

SELECT nomePersonagem, nomeclasse
FROM personagem
RIGHT JOIN classe
ON personagem.idClasse = classe.idClasse

SELECT nomeClasse, nomeHabilidade as 'Habilidade Primaria' 
FROM classe
LEFT JOIN habilidade
ON classe.habilidadePrimaria = habilidade.idHabilidade

SELECT nomeClasse, nomehabilidade Habilidade
From classe
INNER JOIN habilidade
ON classe.habilidadePrimaria = habilidade.idHabilidade

SELECT nomeClasse, nomeHabilidade as 'Habilidade Primaria' 
FROM classe
RIGHT JOIN habilidade
ON classe.habilidadePrimaria = habilidade.idHabilidade

