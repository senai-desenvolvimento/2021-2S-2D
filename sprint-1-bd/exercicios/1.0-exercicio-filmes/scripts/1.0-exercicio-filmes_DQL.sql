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
	
	obs.: tabela1.campo1 é a PK da tabela1
	      tabela2.campo2 é a FK da tabela2 (ou vice-versa)
*/

-- SELECIONAR TODOS OS FILMES E OS GÊNEROS RELACIONADOS
-- LEFT JOIN
SELECT idFilme, tituloFilme, nomeGenero FROM FILME
LEFT JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELAÇÃO COM GÊNERO 
-- E OS TODOS OS OUTROS GÊNEROS 
-- RIGHT JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
RIGHT JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR SOMENTE OS FILMES QUE POSSUEM RELAÇÃO COM GÊNERO
-- INNER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
INNER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;

-- SELECIONAR TODOS OS FILMES E TODOS OS GÊNEROS
-- MESMO QUE NÃO HAJA CORRESPONDÊNCIA
-- FULL OUTER JOIN
SELECT idFilme, tituloFilme, nomeGenero
FROM FILME
FULL OUTER JOIN GENERO
ON FILME.idGenero = GENERO.idGenero;


-- Exemplo com mais de um JOIN

-- SELECIONAR TODOS OS FILMES E TODOS OS GÊNEROS
-- MESMO QUE NÃO HAJA CORRESPONDÊNCIA
-- FULL OUTER JOIN
-- SELECT idFilme, tituloFilme, nomeGenero, nomeDiretor
-- FROM FILME
-- FULL OUTER JOIN GENERO
-- ON FILME.idGenero = GENERO.idGenero
-- FULL OUTER JOIN DIRETOR
-- ON FILME.idDiretor (FK) = DIRETOR.idDiretor (PK);

SELECT nomeGenero, idGenero FROM GENERO WHERE idGenero = 3;

SELECT * FROM USUARIO;

--Busca um usuário através do e-mail e senha
SELECT  idUsuario, email, senha, permissao
FROM usuario
WHERE email = 'saulo@email.com' AND senha = '123';

--Busca um usuário através do idUsuario
SELECT  idUsuario, email, senha, permissao
FROM usuario
WHERE idUsuario = 1;