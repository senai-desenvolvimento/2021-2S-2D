[String_Split()]
DECLARE @tags NVARCHAR(400) = 'Murillo,Pedro,Edson,Matheus,,samuel,Joao'  
  
SELECT value  
FROM STRING_SPLIT(@tags, ',')  
WHERE RTRIM(value) <> '';


[Openxml()]

DECLARE @idoc INT, @doc VARCHAR(1000);  
SET @doc ='  
<ROOT>  
<Customer CustomerID="NOME" ContactName="A VOLTA DOS QUE FORAM">  
   <Order CustomerID="NOME" EmployeeID="5" OrderDate="1996-07-04T00:00:00">  
      <OrderDetail OrderID="10248" ProductID="11" Quantity="12"/>  
      <OrderDetail OrderID="10248" ProductID="42" Quantity="10"/>  
   </Order>  
</Customer>  
<Customer CustomerID="IDADE" ContactName="20MIL ANOS">  
   <Order CustomerID="IDADE" EmployeeID="3" OrderDate="1996-08-16T00:00:00">  
      <OrderDetail OrderID="10283" ProductID="72" Quantity="3"/>  
   </Order>  
</Customer> 
<Customer CustomerID="CARREIRA" ContactName="TRABALHADOR">  
   <Order CustomerID="CARREIRA" EmployeeID="3" OrderDate="1996-08-16T00:00:00">  
      <OrderDetail OrderID="10282" ProductID="73" Quantity="3"/>  
   </Order>  
</Customer> 
</ROOT>';  
--Create an internal representation of the XML document.  
EXEC sp_xml_preparedocument @idoc OUTPUT, @doc;  
-- Execute a SELECT statement that uses the OPENXML rowset provider.  
SELECT    *  
FROM       OPENXML (@idoc, '/ROOT/Customer',1)  
            WITH (CustomerID  VARCHAR(10),  
                  ContactName VARCHAR(20)); 

USE SENAI_HROADS_TARDE;
GO

[Containstable()][dbo].[Classe]
SELECT * FROM Classe
SELECT * FROM CONTAINSTABLE (Classe,nomeClasse,'Monge') ORDER BY RANK DESC;