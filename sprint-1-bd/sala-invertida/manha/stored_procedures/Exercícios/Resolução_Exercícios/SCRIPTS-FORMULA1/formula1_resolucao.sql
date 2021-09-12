USE FORMULA1;
GO

-- Crie um procedimento que altere o nome e a quilometragem do circuito
CREATE PROCEDURE alterar_circuito 
	@indice TINYINT,
	@circuitoNome VARCHAR(70),
	@km TINYINT
AS
	UPDATE circuito SET nomeCircuito = @circuitoNome, quilometragem = @km WHERE idCircuito = @indice
	SELECT * FROM circuito;
GO

EXEC alterar_circuito @indice = 3, @circuitoNome = 'San Marino', @km = 3;
GO


-- Crie um procedimento para excluir ou adicionar dados de um mecânico da competição
CREATE PROCEDURE p_mecanico
	@comando TINYINT,
	@indice INT = NULL,
	@IDequipe INT = NULL, 
	@IDespecialidade INT= NULL,
	@Mnome VARCHAR(70) = NULL,
	@Mdata DATE = NULL,
	@Msalario MONEY = NULL
AS
	IF @comando = 1
		BEGIN
			INSERT INTO mecanicos (idEspecialidade, idEquipe, nomeMecanico, dataEntrada, salario)
			VALUES (@IDespecialidade, @IDequipe, @Mnome, @Mdata, @Msalario)
			SELECT * FROM mecanicos
		END
	ELSE IF @comando = 2
		BEGIN
			DELETE FROM mecanicos WHERE idMecanico = @indice
			SELECT * FROM mecanicos
		END
GO

EXEC p_mecanico @comando = 2, @indice = 4;
GO

EXEC p_mecanico @comando = 1, @IDEquipe = 3, @IDespecialidade = 3, @Mnome = 'Paulo', @Mdata = '13/08/2021', @Msalario = 2000;
GO

-- Com base nos dados da corrida, crie um procedimento que retorne o motor que possibilitou a vitória de uma determinada corrida

CREATE PROCEDURE motorVitorioso
@indice INT
AS
SELECT nomeFabricante, potencia, pesokg, upPreco FROM corrida
	LEFT JOIN piloto
		ON corrida.vencedor = piloto.idPiloto
	LEFT JOIN equipes
		ON equipes.idEquipe = piloto.idEquipe
	LEFT JOIN carro
		ON carro.idEquipe =equipes.idEquipe
	LEFT JOIN fornecedorMotor
		ON carro.idMotor = fornecedorMotor.idMotor
	WHERE idCorrida = @indice
GO

EXEC motorVitorioso 2