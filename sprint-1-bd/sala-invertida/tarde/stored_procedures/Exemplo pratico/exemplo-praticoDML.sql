USE EXEMPLO_CLINICA
GO

INSERT INTO CLINICA(nomeClinica)
VALUES ('pclinics'), ('pclinics+'), ('clivet');
GO

INSERT INTO TIPO(nomeTipo)
VALUES ('CACHORRO'), ('PASSARO'), ('GATO');
GO

INSERT INTO DONO(nomeDono)
VALUES ('Matheus'), ('Marcelo'), ('Gisele');
GO

INSERT INTO RACA(nomeRaca, idTipo)
VALUES ('bulldog', 1), ('calopsita', 2), ('siberiano', 3);
GO

INSERT INTO PET(nomePet, idRaca)
VALUES ('asinha', 2), ('afonso', 3), ('bidu', 1);
GO

INSERT INTO VETERINARIO(nomeVeterinario)
VALUES ('carlos'), ('jonathan'), ('jonas');
GO

INSERT INTO ATENDIMENTO(idVeterinario, idPet, descricaoConsulta, dataConsulta)
VALUES (1, 2, 'desc1', 11/09), (3, 1, 'desc2', 12/09), (2, 3, 'desc 3', 13/09);
GO