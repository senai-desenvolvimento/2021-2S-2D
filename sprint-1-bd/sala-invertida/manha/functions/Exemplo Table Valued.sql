ALTER FUNCTION validacaoDesconto ( @valor smallint )
returns float
as
begin
    declare @retorno as float
    set @retorno = @valor - (@valor * 0.15)
        IF (@valor >= 200)
            set @valor = @retorno
        return @valor
    end
GO

SELECT [dbo].[validacaoDesconto] (150)



Exemplo table valued



USE HROADS
GO

ALTER FUNCTION manaMenor75 ()
RETURNS TABLE
AS
RETURN
    SELECT
    nomePersonagem
    manaMenor75

    FROM
    dbo.Personagem

    WHERE
    manaMax <= 75

GO

SELECT * FROM manaMenor75();