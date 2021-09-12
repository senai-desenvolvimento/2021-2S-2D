USE SENAI;
GO

INSERT INTO DEPARTAMENTOS(nomeDep)
VALUES ('T.I'), ('Limpeza'), ('Segurança'), ('Cozinha');
GO

INSERT INTO FUNCIONARIO(idDep, nomeFunc,dataNasc)
VALUES (4, 'Nayara', '24/08/2004'), (1, 'João (O Brabo)', '20/01/2004'), (3, 'Ana', '18/08/2004'), (2, 'Lucas', '04/10/2003'), (1, 'Júlia', '10/08/2004');
GO