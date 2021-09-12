USE OPTUS_S;
GO


/*

EXERCICIO

Calcule o intervalo de anos entre a data atual e a data de 
lan�amento do album, utilizando a fun��o DATEDIFF

*/

SELECT DATEDIFF(YEAR, dataLancamento, GETDATE()) 
AS 'Diferen�a entre as datas' FROM ALBUM;



SELECT dataLancamento FROM ALBUM






















-- FUN��ES DE CONCATENA��O
SELECT CONCAT('www', '.', 'senai', '.', 'com') AS 'RESULTADO';
SELECT 'www' + '.senai' + '.com' AS 'RESULTADO'; 
SELECT CONCAT_WS('.', 'www', 'senai', 'com') AS 'RESULTADO'; 










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