CREATE DATABASE ALUNO;
GO

USE ALUNO;
GO

CREATE TABLE cadastroAluno(
idAluno INT PRIMARY KEY IDENTITY(1,1),
nomeAluno VARCHAR(150),
nomeEscola VARCHAR(100),
)

CREATE TABLE email(
idAluno INT PRIMARY KEY IDENTITY(1,1),
destinatario VARCHAR(150),
assunto VARCHAR(250),
texto VARCHAR(MAX),
)

--Trigger para enviar um email ao aluno novo que foi cadastrado
ALTER TRIGGER trgEmailAluno
ON cadastroAluno
FOR INSERT 
AS
BEGIN

DECLARE @nomeAluno VARCHAR(150), @nomeEscola VARCHAR(100);

SELECT @nomeAluno = nomeAluno, @nomeEscola = nomeEscola
FROM INSERTED

INSERT INTO email(destinatario, assunto, texto)
VALUES ('gustavo@gmail.com', 'Aluno novo cadastrado','O aluno ' + @nomeAluno + ' da escola ' + @nomeEscola + ' foi cadastrado com sucesso')
END;
GO

INSERT INTO cadastroAluno(nomeAluno, nomeEscola)
VALUES ('Gustavo', 'SENAI Santa Cecilia');
GO

select * from cadastroAluno
select * from email