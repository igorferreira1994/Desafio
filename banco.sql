CREATE TABLE Logradouro(
    IdLogradouro int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Descricao varchar(100) NOT NULL 
	) 

CREATE TABLE Cliente (
    IdCliente int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome varchar(100) NOT NULL,
    Email varchar(100) NOT NULL UNIQUE,
    Logotipo varchar(100) ,
    IdLogradouro int FOREIGN KEY REFERENCES Logradouro(IdLogradouro)
);