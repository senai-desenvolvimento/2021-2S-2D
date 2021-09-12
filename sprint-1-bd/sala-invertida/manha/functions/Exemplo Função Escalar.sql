CREATE DATABASE testeFuncaoScalar
GO
USE testeFuncaoScalar
GO

create function multiplica_por_2(@valorQualquer int) --declarar função
returns int --define o tipo de dado do retorno
as
begin--início da função
return @valorQualquer*2
end
GO

SELECT dbo.multiplica_por_2(2)--define o número a ser multiplicado e realiza a operação