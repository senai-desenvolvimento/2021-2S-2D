USE SENAI_HROADS_MANHA;
GO

--CRIANDO UM PROCEDIMENTO ARMAZENADO
CREATE PROCEDURE Teste;1
	@indice TINYINT-- As vari�veis devem ser declaradas com um '@' 
	AS 
--INTRU��ES QUE SER�O EXECUTADAS:
	SELECT nome Nome, nomeClasse Classe, maxVida Vida FROM personagem
	INNER JOIN classe
	ON classe.idClasse = personagem.idClasse
	WHERE idPersonagem = @indice -- Filtrando a consulta com o valor da vari�vel
GO

-- � poss�vel agrupar procedimentos para exclu�-los simultaneamente, diferenciando-os atrav�s de um n�mero
-- Exemplo: 
-- nomeProc;1
-- nomeProc;2
-- DROP PROCEDURE nomeProc

--Para executar o procedimento (EXECUTE ou EXEC), usa-se a estrutura [EXEC nome_procedimento valorVariavel]
EXEC Teste 3
EXECUTE Teste 1

DROP PROCEDURE Teste -- Apaga o procedimento

-- VISUALIZAR CONTE�DO
EXEC sp_helptext Teste -- sp_helptext exibe todos os comandos a serem excutados dentro de um determinado procedimento


-- ALTERANDO PROCEDIMENTOS CRIADOS ANTERIORMENTE
-- � necess�rio reescrever praticamente todo o bloco de c�digo anterior, mas ao contr�rio do CREATE PROCEDURE,
-- o ALTER PROCEDURE ainda � capaz de manter permiss�es antes estabelecidas:
ALTER PROCEDURE Teste (@Vida TINYINT) 
AS
SELECT nome Nome, nomeClasse Classe, maxVida Vida, maxMana Mana, dataAtualizacao [Atualiza��o], dataCriacao 'Cria��o' FROM personagem
INNER JOIN classe
ON classe.idClasse = personagem.idClasse
WHERE maxVida > @Vida
GO

EXEC Teste @Vida = 95


-- CRIANDO UM PROCEDIMENTO DE INSER��O
CREATE PROCEDURE insere_hab 
@NomeHabilidade VARCHAR(100),
@tipoHab INT
AS
INSERT INTO habilidade (idTipoHab, nomeHabilidade) VALUES (@tipoHab, @NomeHabilidade)

EXEC insere_hab @tipoHab = 3, @NomeHabilidade = 'Cura acelerada';
GO

-- VALORES PADR�ES
CREATE PROCEDURE padrao_personagem 
@id_classe INT,
@p_nome VARCHAR(100),
@p_vida TINYINT = 60, -- Caso o usu�rio n�o forne�a nenhum valor, ser� usado o valor padr�o definido na
@p_mana TINYINT = 60-- pr�pria constru��o do procedimento armazenado
AS
INSERT INTO personagem (idClasse, nome, maxVida, maxMana) 
VALUES (@id_classe, @p_nome, @p_vida, @p_mana);


EXEC padrao_personagem @id_classe = 3, @p_nome = 'Razor', @p_atualizacao = '12/08/2021', @p_criacao = '12/08/2021';
GO

SELECT * FROM personagem

EXEC padrao_personagem @id_classe = 2, @p_nome = 'DOTNET',@p_vida = 80, @p_mana = 75, @p_atualizacao = '12/08/2021', @p_criacao = '12/08/2021';
GO


USE Pclinics;
GO


-- TRABALHANDO COM ESTRUTURAS DE CONTROLE 
CREATE PROCEDURE controlando
@comando TINYINT NULL,
@indice INT = NULL,
@nomeTipo VARCHAR(50) = NULL
AS
SET NOCOUNT ON -- Impede a exibi��o de linhas alteradas nos resultados
IF @comando = 1
BEGIN
	INSERT INTO tipoPet (nomeTipo) VALUES (@nomeTipo)
	SELECT * FROM tipoPet
END
ELSE IF @comando = 2
BEGIN
	DELETE FROM tipoPet WHERE IdTipoPet = @indice
	SELECT * FROM tipoPet;
END
ELSE IF @comando = 3
BEGIN
	UPDATE tipoPet SET nomeTipo = @nomeTipo WHERE IdTipoPet = @indice
	SELECT * FROM tipoPet;
END
GO



