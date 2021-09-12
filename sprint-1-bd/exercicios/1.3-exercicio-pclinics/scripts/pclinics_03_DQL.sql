USE Pclinics_M;
GO

SELECT * FROM Clinica;
GO

SELECT * FROM TiposPet;
GO

SELECT * FROM Raca;
GO

SELECT * FROM Dono;
GO

SELECT * FROM Veterinario;
GO

SELECT * FROM Pet;
GO

SELECT * FROM Atendimento;
GO

-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
SELECT nome, crmv, razaoSocial FROM Veterinario
INNER JOIN Clinica
ON Clinica.idClinica = Veterinario.idClinica
WHERE Clinica.idClinica = 1;

-- listar todas as ra�as que come�am com a letra S
SELECT * FROM Raca
WHERE descricao LIKE 'S%';

-- listar todos os tipos de pet que terminam com a letra O
SELECT * FROM tiposPet
WHERE descricao LIKE '%o';

-- listar todos os pets mostrando os nomes dos seus donos
-- ALIAS (apelido) AS
SELECT idPet, pet.nome pet, dataNascimento AS 'data nascimento', dono.nome AS dono FROM pet
INNER JOIN dono
ON pet.idDono = dono.idDono;

-- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, 
-- o nome, a ra�a e o tipo do pet que foi atendido,
-- o nome do dono do pet e o nome da cl�nica onde o pet foi atendido
SELECT idAtendimento, V.nome [veterin�rio], P.nome pet,
R.descricao [ra�a], TP.descricao [esp�cie], D.nome dono, razaoSocial [raz�o social]
FROM atendimento AS A
LEFT JOIN veterinario V
ON A.idVeterinario = V.idVeterinario
INNER JOIN pet P
ON A.idPet = P.idPet
INNER JOIN raca R
ON P.idRaca = R.idRaca
INNER JOIN tiposPet TP
ON TP.idTipoPet = R.idTipoPet
INNER JOIN dono D
ON P.idDono = D.idDono
INNER JOIN clinica C
ON C.idClinica = V.idClinica;