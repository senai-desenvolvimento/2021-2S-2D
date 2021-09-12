CREATE DATABASE EXEMPLO_NORMAS
GO

USE EXEMPLO_NORMAS
GO

CREATE TABLE FUNCIONARIOS(
	idFuncionario SMALLINT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR(50) NOT NULL,
	telefone VARCHAR(11)NOT NULL,
	email VARCHAR(70)NOT NULL,
	cargo VARCHAR (30) NOT NULL,
	cpf VARCHAR(11) NOT NULL UNIQUE,
	salario SMALLMONEY NOT NULL,
	dataContratacao DATE,
	setor VARCHAR(25) NOT NULL,
);
GO

INSERT INTO FUNCIONARIOS (nome, telefone, email, cargo, cpf, salario, dataContratacao, setor)
VALUES ('Vanessa', '11906234283', 'vanessa@gmail.com', 'Faxineira', '46352637485', 1962.32, '2019-05-17', 'Limpeza'),
('Vanderson', '11976234872', 'vanderson.almeida@gmail.com', 'Auxiliar de Limpeza', '44635274857', 1682.53, '2020-08-13', 'Limpeza'),
('Roberto', '11947565767', 'roberto.silva@gmail.com', 'Auxiliar de RH', '46474437568', 1793.22, '2021-11-26', 'Recursos Humanos'),
('Alessandra', '11974857584', 'alessandra.campos@gmail.com', 'Analista', '43647363744', 2500.00, '2018-10-18', 'Recursos Humanos'),
('Venicius', '11974857584', 'venicius.moreira@gmail.com', 'Recrutador', '23146834173', 1851.33, '2019-01-13', 'Recursos Humanos'),
('Vanessa', '11906234283', 'vanessa@gmail.com', 'Faxineira', '46352527485', 1962.32, '2019-05-17', 'Limpeza'),
('Julio', '11976234872', 'julio.almeida@gmail.com', 'Gerente', '44097764857', 3667.67, '2020-10-15', 'Vendas'),
('Kleber', '11906463123', 'klebinhoDoPren@gmail.com', 'Supervisor', '46934231789', 2600.15, '2021-01-22', 'Vendas');


SELECT * FROM FUNCIONARIOS ORDER BY nome asc;