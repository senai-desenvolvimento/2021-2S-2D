USE LIVRARIA;
GO


--Liste todos os livros com seus respectivos autores, categorias e preços;
SELECT nomeLivro AS [Nome do Livro], autor AS [Autor], nomeCategoria AS [Nome Categoria], precoLivro AS [Preço Livro (R$)]  FROM Livro
FULL OUTER JOIN Categoria
ON Categoria.idCategoria = Livro.idCategoria;
GO

