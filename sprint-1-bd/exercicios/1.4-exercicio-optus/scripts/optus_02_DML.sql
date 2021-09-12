USE Optus;
GO

INSERT INTO Artistas(Nome)
VALUES				('Angra')
				   ,('Madonna')
				   ,('Shaman');
GO

INSERT INTO Estilos(Nome)
VALUES				 ('Rock')
					,('Pop')
					,('Metal');
GO

INSERT INTO Albuns(Titulo, DataLancamento, Localizacao, QtdMinutos, Ativo, IdArtista)
VALUES			  ('Holy Land', '1996', 'Brasil', 57, 1, 1)
				 ,('MDNA', '2012', 'EUA', 75, 0, 2);
GO

INSERT INTO AlbunsEstilos(IdAlbum, IdEstilo)
VALUES			 (1,1)
				,(1,3)
				,(2,1);
GO

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
VALUES				('Saulo', 's.santos@email.com', '123456', 'Administrador')
				   ,('Caique', 'c.zaneti@email.com', '123456', 'Comum');
GO