USE Pclinics_T;
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
SELECT nome, crmv, razaoSocial FROM veterinario
INNER JOIN clinica
ON clinica.idClinica = veterinario.idClinica
WHERE clinica.idClinica = 1;

-- listar todas as raças que começam com a letra S
SELECT * FROM raca
WHERE descricao LIKE 's%';

-- listar todos os tipos de pet que terminam com a letra O
SELECT * FROM tiposPet
WHERE descricao LIKE '%o';

-- listar todos os pets mostrando os nomes dos seus donos
-- ALIAS (apelido) AS
SELECT idPet, Pet.nome AS pet, dataNascimento 'data nascimento', Dono.nome dono 
FROM Pet
LEFT JOIN Dono
ON Dono.idDono = Pet.idDono;

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, 
-- o nome, a raça e o tipo do pet que foi atendido,
-- o nome do dono do pet e o nome da clínica onde o pet foi atendido
SELECT idAtendimento, V.nome [veterinário], P.nome pet, R.descricao [raça],
TP.descricao [espécie], D.nome dono, razaoSocial [razão social]
FROM Atendimento AS A
LEFT JOIN Veterinario V
ON A.idVeterinario = V.idVeterinario
INNER JOIN Pet P
ON A.idPet = P.idPet
INNER JOIN Raca R
ON P.idRaca = R.idRaca
INNER JOIN tiposPet TP
ON R.idTipoPet = TP.idTipoPet
INNER JOIN dono D
ON P.idDono = D.idDono
LEFT JOIN clinica C
ON V.idClinica = C.idClinica;