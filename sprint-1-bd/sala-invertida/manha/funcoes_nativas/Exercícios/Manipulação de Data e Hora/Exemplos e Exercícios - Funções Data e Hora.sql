create database EXERCICIO_FUNCOES_DATA;
GO

USE EXERCICIO_FUNCOES_DATA;
GO

create table pessoa(
   idPessoa tinyint PRIMARY KEY IDENTITY(1,1),
   dataDeNascimento DATE,
);
go

insert into pessoa(dataDeNascimento)
values ('2003-11-23'), ('2002-11-23'), ('1999-11-23'),('2009-11-23')

-----------------------------------------------------------------------------------------

select * from pessoa;

--getdate
select cast(getdate() as date)

--datediff
select datediff(day, '2021-08-01', getdate())

--dateadd
select dateadd(day, +10,cast(getdate() as date))

--datepart
select datepart(weekday, '2021-08-14')

--DATENAME
select DATENAME (day, '2021-08-14')

--between
select * from pessoa where dataDeNascimento between '2000-01-01' and '2010-01-01'


--RESPOSTA EXERCÍCIO 1:
SELECT DATEDIFF(year, (dataDeNascimento), getdate()) FROM pessoa

--RESPOSTA EXERCÍCIO 2:
SELECT DATEADD (year, +80, (dataDeNascimento)) FROM pessoa

--RESPOSTA EXERCÍCIO 3:
SELECT DATEPART(year, (dataDeNascimento)) FROM pessoa WHERE (dataDeNascimento) BETWEEN '2000-01-01' and '2010-01-01'