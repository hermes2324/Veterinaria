CREATE DATABASE Veterinaria;

USE Veterinaria;
go

CREATE TABLE Animal(
ID INT PRIMARY KEY,
Nombre VARCHAR (50),
Especie VARCHAR (50),
Raza VARCHAR (50),
Peso FLOAT,
Talla FLOAT,
FechadeNacimiento DATE
);

select * from Animal
delete from Animal

CREATE TABLE Cita(
Folio INT PRIMARY KEY,
NombreCita VARCHAR(105),
NoTelefono CHAR(10),
FechaYHora DATETIME,
IDAnimal INT,
CostoxCita FLOAT,
Comentario VARCHAR(500),
FOREIGN KEY (IDAnimal) REFERENCES Animal(ID),
);
go
select * from Cita
delete from Cita

SELECT MAX (Folio) FROM Cita 