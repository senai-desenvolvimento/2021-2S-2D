USE Micromanu;
GO

SELECT * FROM Clientes;
GO

SELECT * FROM Colaboradores;
GO

SELECT * FROM Itens;
GO

SELECT * FROM TiposConsertos;
GO

SELECT * FROM Pedidos;
GO

SELECT * FROM PedidosColaboradores;
GO

-- listar todos os pedidos dos clientes
SELECT CL.Nome Cliente, NumEquipamento, Entrada, Saida, IT.Nome Item, TC.Descricao TipoConserto,
CO.Nome Colaborador
FROM Clientes CL
INNER JOIN Pedidos PE
ON CL.IdCliente = PE.IdCliente
INNER JOIN Itens IT
ON PE.IdItem = IT.IdItem
INNER JOIN TiposConsertos TC
ON PE.IdTipoConserto = TC.IdTipoConserto
INNER JOIN PedidosColaboradores PC
ON PE.IdPedido = PC.IdPedido
INNER JOIN Colaboradores CO
ON PC.IdColaborador = CO.IdColaborador;

-- listar todos os pedidos de um determinado cliente, 
-- mostrando quais foram os colaboradores que executaram o serviço, 
-- qual foi o tipo de conserto, qual item foi consertado e o nome deste cliente
SELECT CL.Nome Cliente, NumEquipamento, Entrada, Saida, IT.Nome Item, TC.Descricao TipoConserto,
CO.Nome Colaborador
FROM Clientes CL
INNER JOIN Pedidos PE
ON CL.IdCliente = PE.IdCliente
INNER JOIN Itens IT
ON PE.IdItem = IT.IdItem
INNER JOIN TiposConsertos TC
ON PE.IdTipoConserto = TC.IdTipoConserto
INNER JOIN PedidosColaboradores PC
ON PE.IdPedido = PC.IdPedido
INNER JOIN Colaboradores CO
ON PC.IdColaborador = CO.IdColaborador
WHERE CL.Nome LIKE 'Caique';