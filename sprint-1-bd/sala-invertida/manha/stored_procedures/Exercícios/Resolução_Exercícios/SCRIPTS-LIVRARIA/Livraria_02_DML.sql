USE LIVRARIA;
GO

INSERT INTO Livraria(nomeLivraria)
VALUES ('Curitiba'), ('Saraiva');
GO

INSERT INTO Categoria(nomeCategoria)
VALUES ('Romance'), ('Aventura'), ('Poesia'), ('Ficção');
GO

INSERT INTO Livro (idLivraria, idCategoria, nomeLivro, autor, precoLivro)
VALUES (1, 1, 'Orgulho e Preconceito', 'Jane Austen', 32), (2, 1, 'A culpa é das Estrelas', 'John Green', 28), (1, 2, 'A Rainha Vermelha', ' Victoria Aveyard', 45), (2,2, 'O Último Reino', ' Bernard Cornwell', 35),(2, 2, 'Anjos e Demônios', 'Dan Brown', 19) ,(1, 3, 'A Rosa do Povo', ' Carlos Drummond de Andrade', 49), (1, 4, '1984', 'George Orwell', 22), (2, 4, 'Caixa de Pássaros', 'Josh MAlerman', 12);
GO