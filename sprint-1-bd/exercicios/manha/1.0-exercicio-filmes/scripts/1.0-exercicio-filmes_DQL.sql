USE CATALOGO_M;
GO

SELECT * FROM GENERO;
SELECT * FROM FILME;

/*
	ESTRUTURA DO JOIN

	SELECT nomeCampo1, nomeCampo2
	FROM tabela1
	TIPO JOIN tabela2
	ON tabela1.campo1 = tabela2.campo2
	
	obs.: tabela1.campo1 � a PK da tabela1
	      tabela2.campo2 � a FK da tabela2 (ou vice-versa)
*/

-- SELECIONAR TODOS OS FILMES E OS G�NEROS RELACIONADOS
-- LEFT JOIN
SELECT idFilme, tituloFilme, nomeGenero FROM FILME
LEFT JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELA��O COM G�NERO 
-- E OS TODOS OS OUTROS G�NEROS 
-- RIGHT JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
RIGHT JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELA��O COM G�NERO
-- INNER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
INNER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR TODOS OS FILMES E TODOS OS G�NEROS
-- MESMO QUE N�O HAJA CORRESPOND�NCIA
-- FULL OUTER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
FULL OUTER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;


-- Exemplo com mais de um JOIN

-- SELECIONAR TODOS OS FILMES E TODOS OS G�NEROS
-- MESMO QUE N�O HAJA CORRESPOND�NCIA
-- FULL OUTER JOIN
-- SELECT idFilme, tituloFilme, nomeGenero, nomeDiretor
-- FROM FILME
-- FULL OUTER JOIN GENERO
-- ON FILME.idGenero = GENERO.idGenero
-- FULL OUTER JOIN DIRETOR
-- ON FILME.idDiretor (FK) = DIRETOR.idDiretor (PK);

SELECT nomeGenero, idGenero FROM GENERO WHERE idGenero = 3;


SELECT * FROM USUARIO 


--Busca um usu�rio atrav�s do e-mail e senha
select  idUsuario,email, senha, permissao
from usuario
where email  = 'saulo@email.com'
and senha = '123' 

