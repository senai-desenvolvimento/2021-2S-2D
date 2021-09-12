USE FORMULA1;
GO

INSERT INTO especialidade(nomeEspecialidade) VALUES 
	('Técnico eletrônico'), 
	('Técnico de combustível'),
	('Técnico hidráulico'),
	('Técnico de pneus'),
	('Mecânico de motor');
GO

INSERT INTO fornecedorMotor (nomeFabricante, potencia, pesokg, upPreco) VALUES
	('Ferrari', 600, 500, 1000000),
	('Mercedes', 750, 450, 1800000),
	('Renault', 550, 525, 900000),
	('Honda', 760, 470, 1950000);
GO

INSERT INTO circuito (nomeCircuito, quilometragem, numCurvas) VALUES 
	('José Carlos Pace', 4, 17),
	('Suzuka', 3, 12),
	('Ímola', 5, 13),
	('Mônaco', 3, 9),
	('Silverstone', 6, 18),
	('Spa-Francorchamps', 7, 22);
GO


INSERT INTO equipes (nomeEquipe, numTitulos, ceo, sede) VALUES
	('Mercedes', 8, 'Toto Wolf', 'Alemanha'),
	('Red Bull', 4, 'Christian Horner', 'Áustria'),
	('McLaren', 11, 'Zak Brown', 'Reino Unido'),
	('Ferrari', 20, 'Matia Binotto', 'Itália'),
	('Alpine', 2, 'Laurent Rossi', 'França'),
	('Aston Martin', 0, 'Lawrence Stoll', 'Reino Unido'),
	('Haas', 0, 'Gunther Steiner', 'Estados Unidos'),
	('AlphaTauri', 0, 'Ahmet Mercan', 'Itália'),
	('Williams', 8, 'Claire Williams', 'Reino Unido'),
	('Alfa Romeo', 0, 'Frédéric Vasseur', 'Itália');


INSERT INTO mecanicos (idEquipe, idEspecialidade, nomeMecanico, dataEntrada, salario) VALUES
	(2, 5, 'Saulo', '01/01/2018', 4000),
	(2, 2, 'Lucas', '02/02/2012', 6500),
	(1, 1, 'Odirlei', '03/03/2016', 5200),
	(1, 4, 'Thiago', '04/04/2019', 3900);
GO

INSERT INTO carro (idEquipe, idMotor, nomeModelo, cor, dataLancamento) VALUES
	(1, 2, 'MS21', 'Preto', '01/01/2021'),
	(2, 4, 'RL21', 'Roxo', '02/01/2021'),
	(3, 2, 'MN21', 'Laranja', '03/01/2021'),
	(4, 1, 'FI21', 'Vermelho', '04/01/2021'),
	(5, 3, 'AI21', 'Azul', '05/01/2021'),
	(6, 2, 'AN21', 'Verde', '06/01/2021'),
	(7, 1, 'HS21', 'Branco', '07/01/2021'),
	(8, 4, 'AL21', 'Branco-Preto', '08/01/2021'),
	(9, 2, 'WL21', 'Azul', '09/01/2021'),
	(10, 1, 'AO21', 'Branco-Vermelho', '10/01/2021');
GO

INSERT INTO piloto (idEquipe, nomePiloto, numPiloto, idade, salarioPiloto) VALUES
	(1, 'Lewis Hamilton', '44', '34', 44000000),
	(1, 'Valteri Bottas', '77', '31', 20000000),
	(2, 'Max Verstappen', '33', '23', 23000000),
	(2, 'Sergio Perez', '11', '31', 15000000),
	(3, 'Lando Norris', '4', '21', 13000000),
	(3, 'Daniel Ricciardo', '3', '30', 10000000),
	(4, 'Charles Leclerc', '16', '22', 17000000),
	(4, 'Carlos Sainz', '55', '24', 15000000),
	(5, 'Fernando Alonso', '14', '40', 18000000),
	(5, 'Esteban Ocon', '31', '23', 12000000),
	(6, 'Sebastian Vettel', '5', '36', 20000000),
	(6, 'Lance Stroll', '18', '22', 10000000),
	(7, 'Mick Schumacher', '47', '19', 5000000),
	(7, 'Nikita Mazepin', '9', '21', 2000000),
	(8, 'Pierre Gasly', '10','22', 7000000),
	(8, 'Yuki Tsunoda', '22','18', 2000000),
	(9, 'George Russel', '63','20', 3000000),
	(9, 'Nicolas Latifi', '6','23', 1500000),
	(10, 'Antonio Giovinazzi', '99','27', 3500000),
	(10, 'Kimi Raikkonen', '7', '40', 4000000);
GO

INSERT INTO corrida (idCircuito, vencedor) VALUES 
	(1,2),
	(2,4),
	(3,7),
	(4,2),
	(5,1);