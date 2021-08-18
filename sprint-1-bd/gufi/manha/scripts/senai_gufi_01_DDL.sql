CREATE DATABASE GUFI_MANHA;
GO 

USE GUFI_MANHA 

-- TIPO USUARIO

CREATE TABLE tipoUsuario(
  idTipoUsuario int primary key identity,
  tituloTipoUsuario varchar(30) UNIQUE NOT NULL
);
GO

-- TIPO EVENTO
CREATE TABLE tipoEvento(
  idTipoEvento int primary key identity,
  tituloTipoEvento varchar(50) UNIQUE NOT NULL
);
GO

-- INSTITUICAO 

CREATE TABLE instituicao(
   idInstituicao int primary key identity,
   cnpj char(14) unique not null,
   nomeFantasia varchar(100) not null unique,
   endereco varchar(250) unique not null
);
GO

-- SITUACAO
create table situacao (
idSituacao int primary key identity,
descricao varchar(50)
);
GO


--USUARIO
create table usuario (
   idUsuario int primary key identity,
   idTipoUsuario  int foreign key  references tipoUsuario(idTipoUsuario),
   nomeUsuario varchar(50) NOT NULL,
   email varchar(200) UNIQUE  NOT NULL,
   senha varchar(10) NOT NULL
);
GO


-- EVENTO
create table evento(
  idEvento int  primary key identity,
  idTipoEvento int foreign key  references tipoEvento(idTipoEvento),
  idInstituicao int foreign key  references instituicao(idInstituicao),
  nomeEvento varchar(100) NOT NULL,
  descricao varchar(500) NOT NULL,
  acessoLivre  BIT DEFAULT (1),
  dataEvento DATETIME NOT NULL
  );
GO

--PRESENCA
create table presenca(

 idPresenca int  primary key identity,
 idUsuario int foreign key  references usuario(idUsuario),
 idEvento int  foreign key  references evento(idEvento),
 idSituacao int  foreign key  references situacao(idSituacao) DEFAULT (3)

);
GO


/* RESUMO

 PRIMARY KEY = CHAVE PRIMARIA
 FOREIGN KEY = CHAVE ESTRANGEIRA
 IDENTITY = Define que o campo será auto-incremento e unico e (1,1) 
            inicia do 1 e vai de 1 em 1.
 NOT NULL = Não pode ser nulo, ou seja, é obrigatorio.
 UNIQUE = Campo é unique , ou seja , não se repete.
 DEFAULT = Defineum valor padrão, caso nenhum seja informado.
 GO = Pausa a leitura e executa o bloco de codigo acima.

*/




