USE EMPRESA;
GO 

INSERT INTO PESSOA (nomePessoa)
VALUES ('SAULO'), ('LUCAS');

INSERT INTO TELEFONE (idPessoa,numeroTelefone)
VALUES (1,'9999'), (1,'8888'), (2,'7777');

INSERT INTO EMAIL (idPessoa, end_email)
VALUES (1,'s.santos@email.com'), 
(2,'c.zaneti@email.com');

INSERT INTO CNH (idPessoa, descricao) 
VALUES (1,'1234'), (2,'4334');

