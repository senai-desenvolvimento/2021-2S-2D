USE Optus;
GO

SELECT * FROM Artistas;
GO

SELECT * FROM Estilos;
GO

SELECT * FROM Albuns;
GO

SELECT * FROM AlbunsEstilos;
GO

SELECT * FROM Usuarios;
GO

-- listar todos os usuários administradores, sem exibir suas senhas
SELECT Nome, Email, Permissao FROM Usuarios
WHERE Usuarios.Permissao LIKE 'Administrador'

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT Titulo AS Album, YEAR(DataLancamento) AS Lancamento, Localizacao, QtdMinutos AS Duração, Ativo, Artistas.Nome AS Artista 
FROM Albuns
INNER JOIN Artistas
ON Albuns.IdArtista = Artistas.IdArtista
WHERE Albuns.DataLancamento > '2000'

-- listar os dados de um usuário através do e-mail e senha
SELECT Nome, Email, Permissao FROM Usuarios
WHERE Email LIKE 's.santos@email.com' AND Senha LIKE '123456'

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
SELECT Titulo, DataLancamento, Localizacao, QtdMinutos, Ativo, AR.Nome AS Artista, E.Nome AS Estilo 
FROM Albuns AL
INNER JOIN Artistas AR
ON AL.IdArtista = AR.IdArtista
INNER JOIN AlbunsEstilos AE
ON AL.IdAlbum = AE.IdAlbum
INNER JOIN Estilos E
ON AE.IdEstilo = E.IdEstilo
WHERE AL.Ativo = 'true'