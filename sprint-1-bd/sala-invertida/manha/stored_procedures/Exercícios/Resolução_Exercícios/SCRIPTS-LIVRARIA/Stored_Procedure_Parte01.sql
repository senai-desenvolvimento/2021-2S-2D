USE LIVRARIA;
GO

--Stored Procenures

--Crie uma Procendure que retornem o nome e o pre�o do livro;
-- Cria��o da Procedure
CREATE PROCEDURE P_MostrarLivro
AS
BEGIN
SELECT nomeLivro AS [Nome do Livro], precoLivro AS [Pre�o (R$)]
FROM Livro
END

--Execu��o da Procedure
EXECUTE P_MostrarLivro
