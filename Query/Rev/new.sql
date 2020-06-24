use master
go

create database DBNet
go

use DBNet
go


Create table Usuario(
	idusuario int primary key identity,
	nombre varchar(50),
	correo varchar(50),
	clave varchar(50),
	telefono varchar(15),
	razonsocial varchar(60),
	foto varchar(100),
	activo bit
)
go



Create table Empresa(

	idempresa int primary key identity,
	nmempresa varchar(60) null,
	rucempresa varchar(11) null,
	dirempresa varchar(100) null,
	correoempresa varchar(30) null,
	telefonoempresa varchar(15) null,
	logoempresa varchar(32) null,
	obsempresa varchar(50) null,
	estadoempresa int null
)
go


Create table Cliente(

	id int primary key identity not null,
	razonsocial varchar(60) null,
	ruc varchar(15) null,
	ubicacion int foreign key references Recurso,
	correo varchar(60) null,
	telefono varchar(15) null,
	empresa int foreign key references Empresa,
	activo bit null

)
go







Create table Recurso(

	id int primary key identity not null,
	campo varchar(30) null,
	descripcion varchar(100) null,
	texto varchar(50) null,
	activo bit null

)
go






Create table UCliente(

	id int primary key identity not null,
	usuario int foreign key references Usuario,
	cliente int foreign key references Cliente,
	activo bit null
)
go

Create table UNet(

	id int primary key identity not null,
	usuario int foreign key references Usuario,
	tipo int foreign key references Recurso,
	activo bit null

)
go

Create table Orden(

	id int primary key not null,
	ucliente int foreign key references UCliente,
	unet int foreign key references UNet,
	cliente int foreign key references Cliente,
	ubicacionentrega int foreign key references Recurso,

	tservicedesk varchar(20) null,
	fechasolicitud datetime null, 
	finentrega datetime null,	
	tipoatencion varchar(15) null,

	cuenta varchar(50) null,
	solicitante varchar(50) null,

	proceso varchar(10) null,
	sucursal varchar(100) null,
	responsable varchar(50) null,
	telresponsable varchar(15) null,
	usuarioequipo varchar(50) null,
	pass bit null,
	telusuario varchar(15) null,
	ubicacionequipo varchar(60) null,
	enred bit null,
	referenciaproceso varchar(20) null,
	solicproceso varchar(50) null,

	rq varchar(20) null,
	os varchar(20) null,
	fechaos datetime null,
	rqaprobador varchar(50) null,
	correoaprobador varchar(60) null, 
	motivo varchar(20) null,
	contratomarco varchar(20) null,
	clienteasociado varchar(60) null,
	clienteasociadoruc varchar(20) null,	
	tipocliente varchar(20) null,
	grupoeconomico varchar(60) null,
	contratointerno varchar(15) null,
	refacturable bit null,
	inicioperiodo datetime null,
	finperiodo datetime null,

	refdireccion varchar(100) null,
	contacto varchar(50) null,
	--telefonos varchar(40) null,
	obsgenerales varchar(240) null,
	activo bit null

)
go