CREATE DATABASE BDTask
GO

USE BDTask
GO

CREATE TABLE Tag
(
	TagId	int				primary key		identity,
	Title	varchar(200)	not null		unique
)

INSERT INTO Tag VALUES ('Estudo')
INSERT INTO Tag VALUES ('Trabalho')

CREATE TABLE Usuario
(	
	UsuarioId	int primary key		identity,
	Nome varchar(100) not null,
	Email varchar(100) not null unique,
	Senha varchar(max) not null
)

INSERT INTO Usuario VALUES ('Fulano', 'fulano@email.com', '123')
INSERT INTO Usuario VALUES ('Ciclano', 'ciclano@email.com', '123')

SELECT * FROM Usuario

CREATE TABLE Tarefa
(
	TarefaId int primary key identity,
    Title varchar(max) not null,
    UsuarioId int not null,
    TagId int not null,
	foreign key (UsuarioId) references Usuario (UsuarioId),
	foreign key (TagId) references Tag (TagId),
)
