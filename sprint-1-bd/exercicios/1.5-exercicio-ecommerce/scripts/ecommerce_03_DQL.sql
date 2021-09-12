USE Ecommerce;
GO

SELECT * FROM Lojas;
GO

SELECT * FROM Categorias;
GO

SELECT * FROM SubCategorias;
GO

SELECT * FROM Produtos;
GO

SELECT * FROM Clientes;
GO

SELECT * FROM Pedidos;
GO

SELECT * FROM PedidosProdutos;
GO

-- listar todos os pedidos de um cliente (nome), 
-- mostrando quais produtos foram solicitados (titulo) neste pedido
-- e de qual subcategoria (nome) e categoria (nome) pertencem
SELECT CL.Nome Cliente, PR.Titulo Produto, SC.Nome SubCategoria, CA.Nome Categoria FROM Pedidos PE
INNER JOIN Clientes CL
ON PE.IdCliente = CL.IdCliente
INNER JOIN PedidosProdutos PP
ON PE.IdPedido = PP.IdPedido
INNER JOIN Produtos PR
ON PP.IdProduto = PR.IdProduto
INNER JOIN SubCategorias SC
ON PR.IdSubCategoria = SC.IdSubCategoria
INNER JOIN Categorias CA
ON SC.IdCategoria = CA.IdCategoria;