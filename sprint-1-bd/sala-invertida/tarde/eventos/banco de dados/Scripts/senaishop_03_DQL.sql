USE SENAISHOP_EVENTOS
GO


/*
- listar todos os pedidos de um cliente (nome),
mostrando quais produtos foram solicitados (titulo)
neste pedido e de qual subcategoria (nome)
e categoria (nome) pertencem
*/
SELECT nomeCliente Cliente,nomeProduto Produto,
nomeSubCategoria Subcategoria,nomeCategoria Categoria FROM CLIENTE
RIGHT JOIN PEDIDO P
ON CLIENTE.idCliente = P.idCliente
RIGHT JOIN CARRINHO C
ON C.idPedido = P.idPedido
LEFT JOIN PRODUTO 
ON C.idProduto = PRODUTO.idProduto
LEFT JOIN SUBCATEGORIA Sub
ON PRODUTO.idSubCategoria = Sub.idSubCategoria
LEFT JOIN CATEGORIA 
ON Sub.idCategoria = CATEGORIA.idCategoria
GO

SELECT nomeCliente,nomeProduto,nomeSubCategoria,nomeCategoria FROM CLIENTE
LEFT JOIN PEDIDO
ON CLIENTE.idCliente = PEDIDO.idCliente
FULL OUTER JOIN CARRINHO
ON CARRINHO.idPedido = PEDIDO.idPedido
LEFT JOIN PRODUTO
ON CARRINHO.idProduto = PRODUTO.idProduto
LEFT JOIN SUBCATEGORIA
ON PRODUTO.idSubCategoria = SUBCATEGORIA.idSubCategoria
LEFT JOIN CATEGORIA
ON SUBCATEGORIA.idCategoria = CATEGORIA.idCategoria
WHERE CLIENTE.idCliente = 5
GO
