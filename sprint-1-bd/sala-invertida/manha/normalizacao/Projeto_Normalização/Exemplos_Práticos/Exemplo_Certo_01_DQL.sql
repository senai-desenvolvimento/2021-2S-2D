USE EXEMPLO_NORMAS_CERTO;
GO

SELECT * FROM CARGO;
GO

SELECT * FROM SETOR;
GO

SELECT * FROM CARGOFUNCIONARIO;
GO

SELECT * FROM FUNCIONARIO;
GO

SELECT * FROM EMAIL;
GO

SELECT * FROM TELEFONE;
GO

SELECT FUNCIONARIO.idFuncionario 'Número do funcionário', nomeFuncionario 'Nome do funcionário', numTelefone 'Número do telefone',
endEmail 'Endereço de email', nomeCargo 'Nome do cargo', CPF, salario, dataContratacao 'Data de contratação', nomeSetor 'Nome do setor'
FROM CARGOFUNCIONARIO
INNER JOIN FUNCIONARIO
ON FUNCIONARIO.idCargoFuncionario = CARGOFUNCIONARIO.idCargoFuncionario
INNER JOIN CARGO
ON CARGO.idCargo = CARGOFUNCIONARIO.idCargo
INNER JOIN SETOR
ON SETOR.idSetor = CARGOFUNCIONARIO.idSetor
INNER JOIN TELEFONE
ON TELEFONE.idFuncionario = FUNCIONARIO.idFuncionario
INNER JOIN EMAIL
ON EMAIL.idFuncionario = FUNCIONARIO.idFuncionario
ORDER BY nomeFuncionario asc;
GO