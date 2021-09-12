USE Ecommerce;
GO

INSERT INTO Lojas(Nome)
VALUES			 ('SenaiShop');
GO

INSERT INTO Categorias(Nome, IdLoja)
VALUES				  ('Cursos', 1)
					 ,('Acessórios', 1);
GO

INSERT INTO SubCategorias(Nome, IdCategoria)
VALUES					 ('Informática Básica', 1)
						,('Desenvolvimento', 1)
						,('Meio Ambiente', 2)
						,('Camisetas', 2);
GO

INSERT INTO Produtos(Titulo, Valor, IdSubCategoria)
VALUES				('Copo para café', 25, 3)
				   ,('Jaqueta', 100, 4)
				   ,('Excel Básico', 350, 1)
				   ,('C#', 700, 2);
GO

INSERT INTO Clientes(Nome)
VALUES				('Saulo')
				   ,('Caique');
GO

INSERT INTO Pedidos(NumPedido, IdCliente, DataPedido, [Status])
VALUES			   ('5455514', 1, '22/01/2019', 'Em andamento')
				  ,('23232', 2, '22/01/2019', 'Entregue');
GO

INSERT INTO PedidosProdutos(IdPedido, IdProduto)
VALUES					   (1,1)
						  ,(1,2)
						  ,(2,3)
						  ,(2,4);
GO