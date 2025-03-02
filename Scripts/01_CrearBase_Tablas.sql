

create database DBPrestamo

go

use DBPrestamo

go

create table Cliente(
IdCliente int primary key identity,
NroDocumento varchar(50),
Nombre varchar(50),
Apellido varchar(50),
Correo  varchar(50),
Telefono  varchar(50),
FechaCreacion datetime default getdate()
)

go
create table Garante(
IdGarante int primary key identity,
NroDocumento varchar(50),
Nombre varchar(50),
Apellido varchar(50),
Correo  varchar(50),
Telefono  varchar(50),
FechaCreacion datetime default getdate()
)

go

create table Moneda(
IdMoneda int primary key identity,
Nombre varchar(50),
Simbolo varchar(4),
FechaCreacion datetime default getdate()
)

go


create table Prestamo(
IdPrestamo int primary key identity,
IdCliente int,
IdGarante int,
IdMoneda int,
FechaInicioPago date,
MontoPrestamo decimal(10,2),
InteresPorcentaje decimal(10,2),
NroCuotas int,
FormaDePago varchar(50),--Diario,Semanal,Quincenal,Mensual
ValorPorCuota decimal(10,2),
ValorInteres decimal(10,2),
ValorTotal decimal(10,2),
Estado varchar(50),--Pendiente,Cancelado
FechaCreacion datetime default getdate()
)

go

create table PrestamoDetalle(
IdPrestamoDetalle int primary key identity,
IdPrestamo int references Prestamo(IdPrestamo),
FechaPago date,
NroCuota int,
MontoCuota decimal(10,2),
Estado varchar(50),--Pendiente,Cancelado
FechaPagado datetime ,
FechaCreacion datetime default getdate()
)

go

create table Usuario(
IdUsuario int primary key identity,
NombreCompleto varchar(50),
Correo varchar(50),
Clave varchar(50),
FechaCreacion datetime default getdate()
)

go

insert into Moneda(Nombre,Simbolo) values
('Pesos','$')

go

insert into Usuario(NombreCompleto,Correo,Clave) values
('Maria Jimenez','2022-0384@uteco.edu.do','12345')

INSERT INTO Garante (NroDocumento, Nombre, Apellido, Correo, Telefono)
VALUES ('12345678', 'Juan', 'Pérez', 'juan.perez@email.com', '809-123-4567');
