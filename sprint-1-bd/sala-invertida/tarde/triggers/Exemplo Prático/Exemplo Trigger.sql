Create database Loja;
Go

Use Loja;
Go


Create table CAIXA(
idSaldo int primary key identity(1,1),
Data1 datetime not null,
SaldoInicial Decimal(10,2) not null,
SaldoFinal Decimal(10,2) not null
);
Go

Create table VENDAS(
idVendas int primary key identity (1,1),
Data2 datetime not null,
Valor Decimal(10,2) not null,
Produto varchar(100) not null,
Quantidade decimal(10,0) not null
);
Go

Insert into CAIXA(Data1,SaldoInicial,SaldoFinal)
Values (GETDATE(),100,100);
GO

select * From VENDAS
Select * From CAIXA
GO
-----------------------------------------------------------
/*Criar Trigger na Tabela de VENDAS para atualizar o o valor do CAIXA toda vez 
que for realizado uma nova venda.
Estrutura:

CREATE TRIGGER nomeTrigger
ON nometabela
FOR [inserir, alterar, excluir]
AS -> como
BEGIN

     [AÇÃO]

END
*/

CREATE TRIGGER TGR_Vendas
ON VENDAS
FOR INSERT
AS
BEGIN
	DECLARE 
	@Valor Decimal(10,2),
	@Data2 datetime,
	@Produto Varchar(200),
	@Quantidade decimal(10,0)
	SELECT @Data2 = Data2, @Valor = Valor, @Produto = Produto, @Quantidade = Quantidade From inserted 

	DECLARE
	@SaldoInicial Decimal(10,2),
	@SaldoFinal Decimal(10,2)
	
	SELECT @SaldoInicial = SaldoInicial, @SaldoFinal = SaldoFinal FROM CAIXA  
	
	insert into CAIXA(Data1,SaldoInicial,SaldoFinal) 
	values (@Data2,@SaldoFinal, @SaldoFinal + @Quantidade * @Valor)
END
Go

Insert into VENDAS(Data2,Valor,Produto,Quantidade)
values (GETDATE(),80,'Calça',2)
Go

select * From VENDAS
Select * From CAIXA
GO


DROP TRIGGER TGR_Vendas
DROP TABLE VENDAS
DROP TABLE CAIXA