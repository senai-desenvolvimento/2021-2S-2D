USE LIVRARIA;
GO

--Stored Procenures

--Crie uma Procendure que altere o pre�o de todos os livros de aventura de uma livraria; 
--Cria��o da Procedure
CREATE PROCEDURE P_LivroAlteracaoPreco (@nomeCategoria VARCHAR(20))
AS
BEGIN
UPDATE Livro
SET precoLivro = 10
WHERE Livro.idCategoria = 2
SELECT nomeLivro AS [Nome do Livro],autor AS [Autor], precoLivro AS [Pre�o (R$)] FROM Livro 
-- WHERE Livro.idCategoria = 2 (lista os livros com pre�o alterado)
END

--Execu��o da Procedure
EXECUTE P_LivroAlteracaoPreco @nomeCategoria = 'Aventura'