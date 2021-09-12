USE EXERCICIO
GO


SELECT * FROM Clientes;
GO


-- Deixar mai�sculo
SELECT UPPER (nomeCliente)
FROM Clientes;
GO


-- Deixar min�sculo
SELECT LOWER (nomeCliente)
FROM Clientes;
GO

SELECT TOP 5 UPPER (nomeCliente)
FROM Clientes;
GO

SELECT TOP 2 * 
FROM Clientes
ORDER BY  nomeCliente desc;
GO

SELECT nomeCliente, LEN (nomeCliente)
FROM Clientes;
GO

SELECT nomeCliente, SUBSTRING (nomeCliente,1,3)
FROM Clientes;
GO

SELECT nomeCliente, REPLACE (nomeCliente,'a','o')
FROM Clientes;
GO


--desc = descrever