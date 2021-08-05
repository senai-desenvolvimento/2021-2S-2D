USE EMPRESA;
GO

INSERT INTO PESSOA (nomePessoa)
VALUES ('SAULO'),('LUCAS');
GO

INSERT INTO  TELEFONE (idPessoa,numeroTelefone)
VALUES (3,'999'), (3,'888'), (4,'777');
GO

INSERT INTO EMAIL (idPessoa,end_email)
VALUES (3,'s.santos@email.com'),
	   (4,'l.aragao@email.com');
GO

INSERT INTO CNH (idPessoa,descricao)
VALUES (3,'132')

INSERT INTO CNH (idPessoa,descricao)
VALUES (4,'4343')

