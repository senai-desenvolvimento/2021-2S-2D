USE OPTUS_S;
GO


/*

EXERCICIO

Calcule o intervalo de anos entre a data atual e a data de 
lançamento do album, utilizando a função DATEDIFF

*/

SELECT DATEDIFF(YEAR, dataLancamento, GETDATE()) 
AS 'Diferença entre as datas' FROM ALBUM;



SELECT dataLancamento FROM ALBUM






















-- FUNÇÕES DE CONCATENAÇÃO
SELECT CONCAT('www', '.', 'senai', '.', 'com') AS 'RESULTADO';
SELECT 'www' + '.senai' + '.com' AS 'RESULTADO'; 
SELECT CONCAT_WS('.', 'www', 'senai', 'com') AS 'RESULTADO'; 










-- SOMAR UM VALOR ESPECIFICO (DE DIAS, MESES OU ANOS) A UMA DATA

SELECT dataAtualizacao FROM PERSONAGEM
SELECT DATEADD(DAY, 5, dataAtualizacao) 
AS 'Proxima atualização em:' FROM PERSONAGEM; 





-- CALCULAR INTERVALO ENTRE DATAS, RETORNANDO DIAS, MESES OU ANOS

SELECT dataCriacao, dataAtualizacao FROM PERSONAGEM;
SELECT DATEDIFF(MONTH, dataCriacao, dataAtualizacao) 
AS 'Diferença entre as datas' FROM PERSONAGEM; 







--SUBSTITUIR O CAMPO 'NULL' POR UM TEXTO ESPECIFICO

--15. Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);

SELECT nomePersonagem AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;

SELECT ISNULL(nomePersonagem, 'NÃO CADASTRADO') 
AS 'Nome do Personagem', 
nomeClasse AS 'Nome da Classe' FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.idClasse = CLASSE.idClasse;