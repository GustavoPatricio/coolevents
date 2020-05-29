CREATE DATABASE COOLEVENTS
GO

USE COOLEVENTS
GO

CREATE TABLE tbl_usuario (
	ID_USUARIO INT PRIMARY KEY IDENTITY,
	NOME NVARCHAR(100),
	SOBRENOME NVARCHAR(100),
	EMAIL NVARCHAR(100),
	SENHA NVARCHAR(250),
	NASC DATE,
	SEXO CHAR(1),
	FOTO NVARCHAR(250),
	APELIDO NVARCHAR(100) NULL,
	CIVIL NVARCHAR(100) NULL,
	UF CHAR(2),
	CIDADE VARCHAR(50),
	CEP VARCHAR(13),
	BAIRRO NVARCHAR(50),
	LOGRADOURO NVARCHAR(100),
	NUMERO VARCHAR(10),
	COMPLEMENTO VARCHAR(10) NULL,
	DESCRICAO NVARCHAR(250) NULL,
	PONTUACAO INT

)
GO

CREATE TABLE tbl_listamigos(
	ID_LIST_AMIGOS INT PRIMARY KEY IDENTITY,
	ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO),
	ID_AMIGO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO),
)

GO

CREATE TABLE tbl_tipoevento(
	ID_TIPO INT PRIMARY KEY IDENTITY,
	TIPO NVARCHAR(50),
	DESCRICAO NVARCHAR(200)
)
GO

CREATE TABLE tbl_enquete(
ID_ENQUETE INT PRIMARY KEY IDENTITY,
ID_TIPO INT FOREIGN KEY REFERENCES tbl_tipoevento(ID_TIPO),
IMAGEM NVARCHAR (250),
TITULO NVARCHAR (100),
TEXTO NVARCHAR (250),
PRAZO DATETIME,
OCULTO BIT,
VALOR INT,
QUESTAO_A NVARCHAR (250),
ALTERNATIVA_AA NVARCHAR (100),
ALTERNATIVA_AB NVARCHAR (100),
ALTERNATIVA_AC NVARCHAR (100),
ALTERNATIVA_AD NVARCHAR (100),
QUESTAO_B NVARCHAR (250),
ALTERNATIVA_BA NVARCHAR (100),
ALTERNATIVA_BB NVARCHAR (100),
ALTERNATIVA_BC NVARCHAR (100),
ALTERNATIVA_BD NVARCHAR (100),
)
GO

CREATE TABLE tbl_resultado(
	ID_RESULTADO INT PRIMARY KEY IDENTITY,
	ID_ENQUETE INT FOREIGN KEY REFERENCES tbl_enquete(ID_ENQUETE),
	ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO),
	REALIZADO DATETIME,
	QUESTAO_A CHAR (1),
	QUESTAO_B CHAR (1),
	PONTUACAO INT,	
)
GO


CREATE TABLE tbl_evento(
	ID_EVENTO INT PRIMARY KEY IDENTITY,
	NOME NVARCHAR(100),
	DATA_EVENTO DATETIME,
	DATA_CRIACAO DATETIME,
	INICIO TIME,
	FIM TIME,
	PUBLICO BIT,
	OCULTO BIT,
	MAX_PESSOAS INT,
	DESCRICAO NVARCHAR(200),
	LOGO VARCHAR(250),
	BACKGROUND VARCHAR(250),
	UF CHAR(2),
	CIDADE VARCHAR(50),
	CEP VARCHAR(13),
	BAIRRO NVARCHAR(50),
	LOGRADOURO NVARCHAR(100),
	NUMERO VARCHAR(10),
	COMPLEMENTO VARCHAR(10),
	ID_TIPO INT FOREIGN KEY REFERENCES tbl_tipoevento(ID_TIPO),
	ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO)

)

GO

CREATE TABLE tbl_post(
ID_POST INT PRIMARY KEY IDENTITY,
TITULO NVARCHAR (100),
MENSAGEM NVARCHAR(200),
DATA DATETIME,
HORARIO TIME,
OCULTO BIT,
ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO),
ID_EVENTO INT FOREIGN KEY REFERENCES tbl_evento(ID_EVENTO)
)
GO

CREATE TABLE tbl_comentario(
ID_COMENTARIO INT PRIMARY KEY IDENTITY,
TITULO NVARCHAR (100),
MENSAGEM NVARCHAR(200),
DATA DATETIME,
HORARIO TIME,
OCULTO BIT,
ID_POST INT FOREIGN KEY REFERENCES tbl_post(ID_POST),
ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO)
)
GO

-- tarefa pronta = lista

CREATE TABLE tbl_lista(
	ID_LISTA INT PRIMARY KEY IDENTITY,
	TAREFA NVARCHAR (100),
	ID_TIPO INT FOREIGN KEY REFERENCES tbl_tipoevento(ID_TIPO)	
)
GO

CREATE TABLE tbl_convidado(
ID_CONVIDADO INT PRIMARY KEY IDENTITY,
ID_USUARIO INT FOREIGN KEY REFERENCES tbl_usuario(ID_USUARIO),
ID_EVENTO INT FOREIGN KEY REFERENCES tbl_evento(ID_EVENTO),
CONFIRMADO BIT
)
GO

CREATE TABLE tbl_tarefa(
	ID_TAREFA INT PRIMARY KEY IDENTITY,
	TAREFA NVARCHAR(100),
	ID_EVENTO INT FOREIGN KEY REFERENCES tbl_evento(ID_EVENTO) NULL,
	ID_CONVIDADO INT FOREIGN KEY REFERENCES tbl_convidado(ID_CONVIDADO) NULL

	
)
GO