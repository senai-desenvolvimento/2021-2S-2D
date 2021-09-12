CREATE DATABASE FORMULA1;
GO

USE FORMULA1;
GO

CREATE TABLE circuito (
	idCircuito TINYINT PRIMARY KEY IDENTITY (1,1),
	nomeCircuito VARCHAR(50),
	quilometragem TINYINT,
	numCurvas TINYINT
);
GO

CREATE TABLE especialidade (
	idEspecialidade TINYINT PRIMARY KEY IDENTITY (1,1),
	nomeEspecialidade VARCHAR(100)
);

CREATE TABLE fornecedorMotor (
	idMotor TINYINT PRIMARY KEY IDENTITY (1,1),
	nomeFabricante VARCHAR(100),
	potencia SMALLINT,
	pesokg SMALLINT,
	upPreco MONEY
);

CREATE TABLE equipes (
	idEquipe TINYINT PRIMARY KEY IDENTITY (1,1),
	nomeEquipe VARCHAR(70),
	numTitulos SMALLINT,
	ceo VARCHAR (70),
	sede VARCHAR(70)
);

CREATE TABLE carro (
	idCarro SMALLINT PRIMARY KEY IDENTITY (1,1),
	idMotor TINYINT FOREIGN KEY REFERENCES fornecedorMotor(idMotor),
	idEquipe TINYINT FOREIGN KEY REFERENCES equipes(idEquipe),
	nomeModelo VARCHAR(70),
	cor VARCHAR (70),
	dataLancamento DATE
);

CREATE TABLE mecanicos (
	idMecanico INT PRIMARY KEY IDENTITY (1,1),
	idEquipe TINYINT FOREIGN KEY REFERENCES equipes(idEquipe),
	idEspecialidade TINYINT FOREIGN KEY REFERENCES especialidade(idEspecialidade),
	nomeMecanico VARCHAR(70),
	dataEntrada DATE,
	salario MONEY
);

CREATE TABLE piloto (
	idPiloto TINYINT PRIMARY KEY IDENTITY (1,1),
	idEquipe TINYINT FOREIGN KEY REFERENCES equipes(idEquipe),
	nomePiloto VARCHAR(70),
	numPiloto VARCHAR(5),
	idade VARCHAR(3),
	salarioPiloto MONEY,
);

CREATE TABLE corrida (
	idCorrida INT PRIMARY KEY IDENTITY (1,1),
	idCircuito TINYINT FOREIGN KEY REFERENCES circuito(idCircuito),
	vencedor TINYINT FOREIGN KEY REFERENCES piloto(idPiloto),
);