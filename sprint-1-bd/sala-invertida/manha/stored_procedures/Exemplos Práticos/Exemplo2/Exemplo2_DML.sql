USE RedeSocialGenerica
GO

INSERT INTO Usuario (Username, Nome, Email, Senha, Endereco)
VALUES('hinriqui', 'Henrique', 'henrique@gmail.com', 'henrique123', 'R. Silv�nio Silvio da Silva, SBT'),
      ('�OTeles', 'Leo Teles', 'leoteles@gmail.com', 'teles123', 'Embaixo da Ponte'),
	  ('Anny', 'Anny', 'anny@gmail.com', 'anny123', 'R. Ferreira Ferro Ferraiz, Jaguar�'),
	  ('Bianca', 'Bianca', 'bianca@gmail.com', 'bianca123', 'R. Carvalho Pereira Muda dos Eucalipto, Amazonas'),
	  ('Levanto', 'Caio', 'caio@gmail.com', 'caio123', 'R. Doutor Rei Padre Engenheiro, Osasco'),
	  ('Lucas', 'Lucas', 'Lucas@gmail.com', 'lucas123', 'R. Odirlei Thiago Saulo do Possarle, SENAI'),
	  ('Miri�', 'Miri�', 'miria@gmail.com', 'miria123', 'R. L�rio Girassol Rosa das Orqu�deas, Vila Lobos')
GO

INSERT INTO Post(UserId, Descricao, Imagem)
VALUES(1, 'Baby, baby, baby ohhhh', 'jb.png'),
      (2, 'Fala felas, bora fazer um projetinho?', 'toguro.png'),
	  (3, 'Mo fome :(', NULL)
	  (4, 'Uhuu! Acordei cedo, comi pra krl, partiu SENAI!', NULL),
	  (5, 'Sextou! Hoje � dia de vava.', NULL),
      (6, 'Sexta feira � dia de bail�o com os cria!!!', 'KONDZILLA.png'),
	  (7, 'Acordar cedo � pros fracos! Fora SENAI!', NULL)
GO