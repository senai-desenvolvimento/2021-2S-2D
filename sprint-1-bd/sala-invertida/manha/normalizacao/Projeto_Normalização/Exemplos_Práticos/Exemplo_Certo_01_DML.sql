USE EXEMPLO_NORMAS_CERTO;
GO

INSERT INTO SETOR (nomeSetor)
VALUES ('LIMPEZA'), ('VENDA'),
('RECURSOS HUMANOS');
GO

INSERT INTO CARGO(nomeCargo)
VALUES ('Auxiliar'), ('Faxina'), ('Analista'), ('Recrutador'), ('Gerente'), ('Supervisor');
GO

INSERT INTO CARGOFUNCIONARIO(idSetor, idCargo)
VALUES (1,1), (1,2), (3,1), (3,3), (3,4), (2,5), (2,6);
GO

SELECT idCargoFuncionario, nomeSetor,nomeCargo
FROM CARGOFUNCIONARIO
INNER JOIN CARGO
ON CARGOFUNCIONARIO.idCargo = Cargo.idCargo
INNER JOIN SETOR 
ON CARGOFUNCIONARIO.idSetor = Setor.idSetor;
GO

INSERT INTO FUNCIONARIO(IdCargoFuncionario, nomeFuncionario, CPF, salario, dataContratacao)
VALUES (2, 'Vanessa', '44635274857', 1682.53, '2020-08-13'),
(3, 'Roberto', '46474437568', 1793.22, '2021-11-26'),
(4, 'Alessandra', '43647363744', 2500.00, '2018-10-18'),
(5, 'Venicius', '23146834173', 1851.33, '2019-01-13'),
(6, 'Julio', '44097764857', 3667.67, '2020-10-15'),
(7, 'Kleber', '46934231789', 2600.15, '2021-01-22'),
(1, 'Vanderson', '45615648842', 1793.22, '2020-08-13');
GO


INSERT INTO EMAIL(idFuncionario, endEmail)
VALUES (1, 'vanessa@gmail.com'),
(1, 'vanessinha@hotmail.com'),
(2, 'roberto.silva@gmail.com'),
(3, 'alessandra.campos@gmail.com'),
(4, 'venicius.moreira@gmail.com'),
(5, 'julio.almeida@gmail.com'),
(6, 'klebinhoDoPren@gmail.com'),
(7, 'vanderson.almeida@gmail.com');
GO

INSERT INTO TELEFONE(idFuncionario, numTelefone)
VALUES (1, '11906234283'),
(2, '11947565767'),
(3, '11974857584'),
(4, '11974857584'),
(5, '11976234872'),
(6, '11906463123'),
(6, '11932343609'),
(7, '11976234872');
GO
