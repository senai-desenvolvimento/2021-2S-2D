USE EXEMPLO_CLINICA
GO

SELECT * FROM CLINICA
SELECT * FROM TIPO
SELECT * FROM DONO
SELECT * FROM PET
SELECT * FROM RACA
SELECT * FROM VETERINARIO
SELECT * FROM ATENDIMENTO
GO

CREATE PROCEDURE teste(
    @nomePet VARCHAR(20)
) 
as
SELECT nomeVeterinario, nomePet, nomeRaca, nomeTipo, nomeDono, nomeClinica FROM ATENDIMENTO
INNER JOIN VETERINARIO
ON ATENDIMENTO.idAtendimento = VETERINARIO.idVeterinario
INNER JOIN PET
ON ATENDIMENTO.idAtendimento = PET.idPet
INNER JOIN RACA
ON ATENDIMENTO.idAtendimento = RACA.idRaca
INNER JOIN TIPO
ON ATENDIMENTO.idAtendimento = TIPO.idTipo
INNER JOIN DONO
ON ATENDIMENTO.idAtendimento = DONO.idDono
INNER JOIN CLINICA
ON ATENDIMENTO.idAtendimento = CLINICA.idClinica
where nomePet = @nomePEt
GO

exec teste 'aaa'
GO