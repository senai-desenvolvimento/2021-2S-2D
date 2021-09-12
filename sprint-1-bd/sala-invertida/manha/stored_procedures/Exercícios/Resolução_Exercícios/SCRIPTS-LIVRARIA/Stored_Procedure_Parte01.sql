USE LIVRARIA;
GO

--Stored Procenures

--Crie uma Procendure que retornem o nome e o preço do livro;
-- Criação da Procedure
CREATE PROCEDURE P_MostrarLivro
AS
BEGIN
SELECT nomeLivro AS [Nome do Livro], precoLivro AS [Preço (R$)]
FROM Livro
END

--Execução da Procedure
EXECUTE P_MostrarLivro
