USE LIVRARIA;
GO


--Liste todos os livros com seus respectivos autores, categorias e pre�os;
SELECT nomeLivro AS [Nome do Livro], autor AS [Autor], nomeCategoria AS [Nome Categoria], precoLivro AS [Pre�o Livro (R$)]  FROM Livro
FULL OUTER JOIN Categoria
ON Categoria.idCategoria = Livro.idCategoria;
GO

