CREATE DATABASE testeFuncaoScalar
GO
USE testeFuncaoScalar
GO

create function multiplica_por_2(@valorQualquer int) --declarar fun��o
returns int --define o tipo de dado do retorno
as
begin--in�cio da fun��o
return @valorQualquer*2
end
GO

SELECT dbo.multiplica_por_2(2)--define o n�mero a ser multiplicado e realiza a opera��o