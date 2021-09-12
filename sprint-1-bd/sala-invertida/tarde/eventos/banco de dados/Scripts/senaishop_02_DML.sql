USE SENAISHOP_EVENTOS
GO

INSERT INTO CLIENTE (CPF,nomeCliente)
VALUES	('58795784712','Gustavo'),
		('64815402312','Amanda'),
		('03475831202','Renato'),
		('64898725612','Paulo'),
		('02056703415','Melissa')
GO

INSERT INTO CATEGORIA (nomeCategoria)
VALUES	('Eletronicos'),('Decorativos'),
		('Calçados'),('Brinquendos'),
		('Cosmédicos'),('Importados')
GO

INSERT INTO SUBCATEGORIA (idCategoria,nomeSubCategoria)
VALUES	(1,'Computadores'),(2,'Lustres'),
		(2,'Vasos'),(3,'Chuteiras'),
		(5,'Batom'),(6,'Solventes'),
		(4,'Hot Wheels'),(4,'Tabuleiros'),
		(3,'Sapatos')
GO

INSERT INTO PRODUTO (idSubCategoria,nomeProduto,preco)
VALUES	(1,'Placa de Vídeo EVGA NVIDIA GeForce GTX 1660',3399.90),
		(6,'Nafta 1Litro',200),
		(7,'Pista Hot Wheels Mattel Ataque Tubarão',230),
		(4,'Chuteira Futsal Nike',150),
		(3,'Vaso Ambar - Azul',399),
		(2,'Lustre - Pendente Bacia Rosé Gold',450),
		(9,'Sapato Social Preto',200),
		(1,'Processador Intel Core i5-10400F',1100)
GO

INSERT INTO PEDIDO (idCliente)
VALUES	(1),(2),(5),(4),(1),(5)
GO

INSERT INTO CARRINHO (idPedido,idProduto)
VALUES	(1,8),(3,5),(5,5),(6,1),
		(1,3),(2,4),(6,5),(4,3),
		(5,2),(3,8),(1,7),(5,3),
		(6,7),(3,6)
GO

INSERT INTO CARRINHO (idPedido,idProduto)
VALUES (1,2)