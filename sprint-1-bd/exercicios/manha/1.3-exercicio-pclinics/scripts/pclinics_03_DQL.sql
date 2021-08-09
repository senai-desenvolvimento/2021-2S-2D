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

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT nome, crmv, razaoSocial FROM Veterinario
INNER JOIN Clinica
ON Clinica.idClinica = Veterinario.idClinica
WHERE Clinica.idClinica = 1;

-- listar todas as raças que começam com a letra S
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

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, 
-- o nome, a raça e o tipo do pet que foi atendido,
-- o nome do dono do pet e o nome da clínica onde o pet foi atendido
SELECT idAtendimento, V.nome [veterinário], P.nome pet,
R.descricao [raça], TP.descricao [espécie], D.nome dono, razaoSocial [razão social]
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