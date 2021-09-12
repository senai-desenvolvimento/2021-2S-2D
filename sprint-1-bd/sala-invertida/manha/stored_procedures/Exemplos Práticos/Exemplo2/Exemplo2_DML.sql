USE RedeSocialGenerica
GO

INSERT INTO Usuario (Username, Nome, Email, Senha, Endereco)
VALUES('hinriqui', 'Henrique', 'henrique@gmail.com', 'henrique123', 'R. Silvânio Silvio da Silva, SBT'),
      ('ÉOTeles', 'Leo Teles', 'leoteles@gmail.com', 'teles123', 'Embaixo da Ponte'),
	  ('Anny', 'Anny', 'anny@gmail.com', 'anny123', 'R. Ferreira Ferro Ferraiz, Jaguaré'),
	  ('Bianca', 'Bianca', 'bianca@gmail.com', 'bianca123', 'R. Carvalho Pereira Muda dos Eucalipto, Amazonas'),
	  ('Levanto', 'Caio', 'caio@gmail.com', 'caio123', 'R. Doutor Rei Padre Engenheiro, Osasco'),
	  ('Lucas', 'Lucas', 'Lucas@gmail.com', 'lucas123', 'R. Odirlei Thiago Saulo do Possarle, SENAI'),
	  ('Miriã', 'Miriã', 'miria@gmail.com', 'miria123', 'R. Lírio Girassol Rosa das Orquídeas, Vila Lobos')
GO

INSERT INTO Post(UserId, Descricao, Imagem)
VALUES(1, 'Baby, baby, baby ohhhh', 'jb.png'),
      (2, 'Fala felas, bora fazer um projetinho?', 'toguro.png'),
	  (3, 'Mo fome :(', NULL)
	  (4, 'Uhuu! Acordei cedo, comi pra krl, partiu SENAI!', NULL),
	  (5, 'Sextou! Hoje é dia de vava.', NULL),
      (6, 'Sexta feira é dia de bailão com os cria!!!', 'KONDZILLA.png'),
	  (7, 'Acordar cedo é pros fracos! Fora SENAI!', NULL)
GO