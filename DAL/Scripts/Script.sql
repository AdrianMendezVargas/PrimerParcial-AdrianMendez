create database ArticulosDb
go
use ArticulosDb
go
create table Articulos(
	
	ProductoId int primary key identity,
	Descripcion varchar(30),
	Existencia int,
	Costo decimal,
	ValorInventario decimal

);