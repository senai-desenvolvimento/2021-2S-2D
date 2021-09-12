USE LIVRARIA;
GO

--Stored Procenures

--Crie uma Procendure que retornem os livros de apenas uma livraria (possui parâmetro);
-- Criação da Procedure
CREATE PROCEDURE P_LivroLivraria (@idLivraria SMALLINT)
AS 
BEGIN
SELECT nomeLivro AS [Nome do Livro],autor AS [Autor] , precoLivro AS [Preço (R$)]
FROM Livro
INNER JOIN Livraria
ON Livraria.idLivraria = Livro.idLivraria
WHERE  Livraria.idLivraria = 2
END


--Execução da Procedure
EXECUTE P_LivroLivraria @idLivraria = 2