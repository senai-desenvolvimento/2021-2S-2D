USE EXERCICIO
GO


SELECT * FROM Clientes;
GO


-- Deixar maiúsculo
SELECT UPPER (nomeCliente)
FROM Clientes;
GO


-- Deixar minúsculo
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