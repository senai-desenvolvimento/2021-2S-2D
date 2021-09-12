
USE SENAI_HROADS_TARDE;
GO

SELECT nomePersonagem, dataCriacao FROM PERSONAGEM

-- RETORNAR CAMPOS DE DATA SEPARADAMENTE
SELECT nomePersonagem, DATENAME(YEAR, dataCriacao) AS 'ANO DE CRIA��O' FROM PERSONAGEM
SELECT nomePersonagem, DATEPART(YEAR, dataCriacao) AS 'ANO DE CRIA��O' FROM PERSONAGEM;

SELECT nomePersonagem, DATENAME(MONTH, dataCriacao) AS 'M�S DE CRIA��O' FROM PERSONAGEM
SELECT nomePersonagem, DATEPART(MONTH, dataCriacao) AS 'M�S DE CRIA��O' FROM PERSONAGEM;

SELECT nomePersonagem, DATENAME(DAY, dataCriacao) AS 'DIA DE CRIA��O' FROM PERSONAGEM
SELECT nomePersonagem, DATEPART(DAY, dataCriacao) AS 'DIA DE CRIA��O' FROM PERSONAGEM;
SELECT nomePersonagem, DATEPART(DAYOFYEAR, dataCriacao) AS 'DIA DO ANO' FROM PERSONAGEM;


-- RETORNAR A DATA E HORA ATUAIS DO SISTEMA OPERACIONAL
SELECT GETDATE() AS 'DATA E HORA ATUALIZADA'; 

 
-- SOMAR UM VALOR ESPECIFICO (DE DIAS, MESES OU ANOS) A UMA DATA

SELECT dataAtualizacao FROM PERSONAGEM
SELECT DATEADD(DAY, 5, dataAtualizacao) 
AS 'Proxima atualiza��o em:' FROM PERSONAGEM; 


-- CALCULAR INTERVALO ENTRE DATAS, RETORNANDO DIAS, MESES OU ANOS

SELECT dataCriacao, dataAtualizacao FROM PERSONAGEM;
SELECT DATEDIFF(MONTH, dataCriacao, dataAtualizacao) 
AS 'Diferen�a entre as datas' FROM PERSONAGEM; 

-- -----------------------------------------------------------------------------------------------------------

-- INVERTER UMA STRING
SELECT REVERSE(nomePersonagem)
FROM PERSONAGEM; 


-- FUN��ES DE CONCATENA��O
SELECT CONCAT('www', '.', 'senai', '.', 'com') AS 'RESULTADO';
SELECT 'www' + '.senai' + '.com' AS 'RESULTADO'; 
SELECT CONCAT_WS('.', 'www', 'senai', 'com') AS 'RESULTADO'; 


-- IDENTIFICAR A POSI��O SEQUENCIAL DE UM CARACTER NA STRING
SELECT CHARINDEX('A', 'SENAI') AS 'Posi��o do caracter:';


-- SUSBTITUIR UM CARACTERE NA STRING
SELECT REPLACE('Descriminar', 'e', 'i') AS 'Ap�s substitui��o';





--SUBSTITUIR O CAMPO 'NULL' POR UM TEXTO ESPECIFICO

--15. Selecionar todos os personagens e as classes (mesmo que elas n�o tenham correspond�ncia em personagens);

SELECT nomePersonagem AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;

SELECT ISNULL(nomePersonagem, 'N�O CADASTRADO') 
AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;






SET TEXTSIZE 0
SET NOCOUNT ON
DECLARE @intCounter int
SET @intCounter = 0

WHILE (@intCounter<= 255)
	BEGIN
		SELECT 'CHAR - ' + CHAR(@intCounter) + '. ASCII - ' + CONVERT(VARCHAR,@intCounter) 
		SET @intCounter = @intCounter + 1
	END


SET NOCOUNT OFF





/*
EXERCICIO
Calcule o intervalo de dias entre a data atual e a data de lan�amento do album, utilizando a fun��o DATEDIFF
*/

SELECT DATEDIFF(DAY, dataCriacao, GETDATE()) 
AS 'Diferen�a entre as datas' FROM PERSONAGEM;


























-- FUN��ES DE CONCATENA��O

SELECT CONCAT('www', '.', 'senai', '.', 'com') AS 'RESULTADO';

SELECT CONCAT_WS('.', 'www', 'senai', 'com') AS 'RESULTADO';

SELECT 'www' + '.senai' + '.com' AS 'RESULTADO';










-- SOMAR UM VALOR ESPECIFICO (DE DIAS, MESES OU ANOS) A UMA DATA

SELECT dataAtualizacao FROM PERSONAGEM
SELECT DATEADD(DAY, 5, dataAtualizacao) 
AS 'Proxima atualiza��o em:' FROM PERSONAGEM; 





-- CALCULAR INTERVALO ENTRE DATAS, RETORNANDO DIAS, MESES OU ANOS

SELECT dataCriacao, dataAtualizacao FROM PERSONAGEM;
SELECT DATEDIFF(MONTH, dataCriacao, dataAtualizacao) 
AS 'Diferen�a entre as datas' FROM PERSONAGEM; 







--SUBSTITUIR O CAMPO 'NULL' POR UM TEXTO ESPECIFICO

--15. Selecionar todos os personagens e as classes (mesmo que elas n�o tenham correspond�ncia em personagens);

SELECT nomePersonagem AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;

SELECT ISNULL(nomePersonagem, 'N�O CADASTRADO') 
AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;