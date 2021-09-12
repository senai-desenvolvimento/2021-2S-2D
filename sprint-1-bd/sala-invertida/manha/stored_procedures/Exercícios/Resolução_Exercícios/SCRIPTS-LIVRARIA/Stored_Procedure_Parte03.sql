USE LIVRARIA;
GO

--Stored Procenures

--Crie uma Procendure que altere o preço de todos os livros de aventura de uma livraria; 
--Criação da Procedure
CREATE PROCEDURE P_LivroAlteracaoPreco (@nomeCategoria VARCHAR(20))
AS
BEGIN
UPDATE Livro
SET precoLivro = 10
WHERE Livro.idCategoria = 2
SELECT nomeLivro AS [Nome do Livro],autor AS [Autor], precoLivro AS [Preço (R$)] FROM Livro 
-- WHERE Livro.idCategoria = 2 (lista os livros com preço alterado)
END

--Execução da Procedure
EXECUTE P_LivroAlteracaoPreco @nomeCategoria = 'Aventura'