USE Veiculos;
GO

SELECT * FROM Empresas;
GO

SELECT * FROM Marcas;
GO

SELECT * FROM Modelos;
GO

SELECT * FROM Veiculos;
GO

SELECT * FROM Clientes;
GO

SELECT * FROM Alugueis;
GO

-- listar todos os alugueis mostrando as datas de início e fim,
-- o nome do cliente que alugou e nome do modelo do carro
SELECT DataInicio, DataFim, Clientes.Nome AS Cliente, Modelos.Descricao AS Modelo, Veiculos.Placa
FROM Alugueis
INNER JOIN Clientes
ON Alugueis.IdCliente = Clientes.IdCliente
INNER JOIN Veiculos
ON Alugueis.IdVeiculo = Veiculos.IdVeiculo
INNER JOIN Modelos
ON Modelos.IdModelo = Veiculos.IdModelo
GO

-- listar os alugueis de um determinado cliente mostrando seu nome, 
-- as datas de início e fim e o nome do modelo do carro
SELECT DataInicio, DataFim, Clientes.Nome AS Cliente, Modelos.Descricao AS Modelo, Veiculos.Placa
FROM Alugueis
INNER JOIN Clientes
ON Alugueis.IdCliente = Clientes.IdCliente
INNER JOIN Veiculos
ON Alugueis.IdVeiculo = Veiculos.IdVeiculo
INNER JOIN Modelos
ON Modelos.IdModelo = Veiculos.IdModelo
WHERE Clientes.Nome = 'Saulo';
GO