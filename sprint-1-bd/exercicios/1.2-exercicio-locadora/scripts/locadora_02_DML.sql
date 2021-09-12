USE Veiculos;
GO

INSERT INTO Empresas(Nome)
VALUES				('Unidas')
				   ,('Localiza');
GO

INSERT INTO Marcas(Nome)
VALUES			  ('Ford')
				 ,('GM')
				 ,('Fiat');
GO

INSERT INTO Modelos (Descricao, IdMarca)
VALUES			    ('Fiesta', 1)
				   ,('Onix', 2)
				   ,('Argo', 3);
GO

INSERT INTO Veiculos (IdModelo, Placa, IdEmpresa)
VALUES				 (1, 'HEL1805', 1)
					,(2, 'FER1010', 1)
					,(3, 'POR1978', 2)
					,(1, 'LEM9876', 2);
GO

INSERT INTO Clientes(Nome, CPF)
VALUES				('Saulo', '99999999999')
				   ,('Caique', '88888888888');
GO

INSERT INTO Alugueis (IdCliente, IdVeiculo, DataInicio, DataFim)
VALUES				 (1, 1, '19/01/2019', '20/01/2019')
					,(1, 2, '20/01/2019', '21/01/2019')
					,(2, 3, '21/01/2019', '21/01/2019')
					,(2, 2, '22/01/2019', '22/01/2019');
GO