use master go
go

create database DBNet
go

use DBNet
go

Create table Recurso(

	id int primary key not null,
	campo varchar(30) null,
	descripcion varchar(100) null,
	texto varchar(50) null,
	activo bit null

)

Create table Empresa(

	id int primary key not null,
	razonsocial varchar(60) null,
	ruc varchar(15) null,
	ubicacion int foreign key references Recurso,
	correo varchar(60) null,
	telefono varchar(15) null,
	activo bit null

)

Create table Cliente(

	id int primary key not null,
	razonsocial varchar(60) null,
	ruc varchar(15) null,
	ubicacion int foreign key references Recurso,
	correo varchar(60) null,
	telefono varchar(15) null,
	empresa int foreign key references Empresa,
	activo bit null

)

Create table Usuario(

	id int primary key identity not null,
	nombre varchar(50) null,
	correo varchar(50) null,
	clave varchar(50) null,
	telefono varchar(15) null,
	activo bit null

)

Select * from Usuario

Create table UCliente(

	id int primary key not null,
	usuario int foreign key references Usuario,
	cliente int foreign key references Cliente,
	activo bit null

)

Create table UNet(

	id int primary key not null,
	usuario int foreign key references Usuario,
	tipo int foreign key references Recurso,
	activo bit null

)

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

Create table DetalleOrden(

	id int primary key not null,
	orden int foreign key references Orden,
	--equipo int foreign key references Hardware,
	tipo tinyint null,
	dolares bit null,
	preciounitario decimal(7,2) null,
	activo bit null

)

--Create table Fose(

--	id int primary key not null,
--	serie varchar(15) null,
	
--	tservicedesk varchar(20) null,
--	fechasolicitud datetime null, 
--	finentrega datetime null,	
--	tipoatencion varchar(15) null,

--	cuenta varchar(50) null,
--	solicitante varchar(50) null,

--	cliente varchar(60) null,
--	ruc varchar(20) null,
--	direccion varchar(100) null,
--	telefono varchar(30) null,

--	proceso varchar(10) null,
--	sucursal varchar(100) null,
--	responsable varchar(50) null,
--	telresponsable varchar(15) null,
--	usuarioequipo varchar(50) null,
--	pass bit null,
--	telusuario varchar(15) null,
--	ubicacionequipo varchar(60) null,
--	enred bit null,
--	referenciaproceso varchar(20) null,
--	solicproceso varchar(50) null,

--	rq varchar(20) null,
--	os varchar(20) null,
--	fechaos datetime null,
--	rqaprobador varchar(50) null,
--	correoaprobador varchar(60) null, 
--	motivo varchar(20) null,
--	contratomarco varchar(20) null,
--	clienteasociado varchar(60) null,
--	clienteasociadoruc varchar(20) null,	
--	tipocliente varchar(20) null,
--	grupoeconomico varchar(60) null,
--	contratointerno varchar(15) null,
--	refacturable bit null,
--	inicioperiodo datetime null,
--	finperiodo datetime null,

--	direccionentrega varchar(100) null,
--	refdireccion varchar(100) null,
--	contacto varchar(50) null,
--	telefonos varchar(40) null,
--	obsgenerales varchar(240) null,
--	activo bit null

--)

--Create table DetalleFose(

--	id int primary key not null,
--	fose int foreign key references Fose,
--	equipo varchar(20) null,
--	tipo tinyint null,
--	cantidad int null,
--	adicionl varchar(200) null,
--	observaciones varchar(200) null,
--	activo bit null

--)

Create table GuiaRemision(

	id int primary key not null,
	serie varchar(15) null,
	unet varchar(30) null,

	razonsocial varchar(60) null,
	ruc varchar(60) null,
	fechaemision datetime null,
	fechatraslado datetime null,
	lugarpartida varchar(200) null,
	lugarllegada varchar(200) null,

	vehiculo varchar(40) null,
	placa varchar(20) null,
	certificado varchar(40) null,
	brevete varchar(40) null,

	--Datos del equipo	
	ntb varchar(10) null,
	tipo varchar(20) null,	
	marca varchar(30) null,
	modelo varchar(20) null,
	lote varchar(20) null,
	bateria varchar(30) null,
	cargador varchar(30) null,
	procesador varchar(20) null,
	velocidad varchar(10) null,
	ram varchar(10) null,
	discoduro varchar(10) null,
	software varchar(30) null,
	hostname varchar(20) null,
	cableseg varchar(20) null,
	mouse varchar(20) null,
	maletin varchar(20) null,
	observacion varchar(240) null,
	
	motivo varchar(20) null,
	factura varchar(15) null,
	proceso varchar(10) null,
	inicioperiodo datetime null,
	finperiodo datetime null,
	fose varchar(20) null,
	os varchar(20) null,
	rq varchar(20) null,
	contrato varchar(15) null,

	estado varchar(20),
	activo bit null

)

Create table Proceso(

	id int primary key not null,
	codigo varchar(15) null,
	guiaremision varchar(15) null,
	periodo int null,
	fose varchar(20) null,
	documento varchar(20) null,
	numdocumento varchar(20) null,
	emitido bit null,
	emicion datetime null,
	recepcion datetime null,
	inifacturacion datetime null,
	finfacturacion datetime null,
	refacturable bit null,
	fechavencimiento datetime null,
	fechapago datetime null,
	contratopago varchar(20) null,
	--cliente
	cliente varchar(40) null,
	ruc varchar(20) null,
	responsable varchar(40) null,
	diascredito tinyint null,
	suc tinyint null,
	empresa varchar(40) null,
	rucempresa varchar(20) null,
	usuarioequipo varchar(40) null,
	pass bit null,
	os varchar(20) null,
	fechaos datetime null,
	rq varchar(20) null,
	contrato varchar(20) null,
	--equipo
	ntb varchar(10) null,
	tipo varchar(20) null,	
	marca varchar(30) null,
	modelo varchar(20) null,
	lote varchar(20) null,
	bateria varchar(30) null,
	cargador varchar(30) null,
	procesador varchar(20) null,
	velocidad varchar(10) null,
	ram varchar(10) null,
	discoduro varchar(10) null,
	software varchar(30) null,
	hostname varchar(20) null,
	cableseg varchar(20) null,
	mouse varchar(20) null,
	maletin varchar(20) null,
	licenciaoffice varchar(30) null,
	usuarioffice varchar(20) null,
	tipoequipo tinyint null,
	dolar bit null,
	precio decimal(7,2) null,
	igv tinyint null,
	total decimal(7,2) null,
	observacion varchar(200) null,
	activo bit null

)

Create table SeguimientoProceso(

	id int primary key not null,
	proceso varchar(20) null,
	equiponombre varchar(20) null,
	estado varchar(20) null,
	unet varchar(30) null,
	datohistorico varchar(240) null,
	--Datos de proceso
	guiaremision varchar(15) null,
	periodo int null,
	fose varchar(20) null,
	documento varchar(20) null,
	numdocumento varchar(20) null,
	emitido bit null,
	emicion datetime null,
	recepcion datetime null,
	inifacturacion datetime null,
	finfacturacion datetime null,
	refacturable bit null,
	fechavencimiento datetime null,
	fechapago datetime null,
	contratopago varchar(20) null,
	cliente varchar(40) null,
	ruc varchar(20) null,
	responsable varchar(40) null,
	diascredito tinyint null,
	suc tinyint null,
	empresa varchar(40) null,
	rucempresa varchar(20) null,
	usuarioequipo varchar(40) null,
	pass bit null,
	os varchar(20) null,
	fechaos datetime null,
	rq varchar(20) null,
	contrato varchar(20) null,
	ntb varchar(10) null,
	tipo varchar(20) null,	
	marca varchar(30) null,
	modelo varchar(20) null,
	lote varchar(20) null,
	bateria varchar(30) null,
	cargador varchar(30) null,
	procesador varchar(20) null,
	velocidad varchar(10) null,
	ram varchar(10) null,
	discoduro varchar(10) null,
	software varchar(30) null,
	hostname varchar(20) null,
	cableseg varchar(20) null,
	mouse varchar(20) null,
	maletin varchar(20) null,
	licenciaoffice varchar(30) null,
	usuarioffice varchar(20) null,
	tipoequipo tinyint null,
	dolar bit null,
	precio decimal(7,2) null,
	igv tinyint null,
	total decimal(7,2) null,
	observacion varchar(200) null,
	activo bit null
)

Create table GuiaRecepcion(

	id int primary key not null,
	serie varchar(15) null,	
	cliente varchar(40) null,
	ruc varchar(20) null,
	ubicacion varchar(200) null,
	responsable varchar(20) null,
	fecharecepcion datetime null,
	telefono varchar(20) null,

	asunto varchar(200) null,
	lugarecepcion varchar(20) null,
	proceso varchar(15) null,
	guiaremision varchar(20) null,
	
	serviciotecnico bit null,
	sinpedido bit null,
	garantia bit null,
	stalquilado bit null,
	devolucion bit null,
	facturable bit null,
	contrato bit null,
	otros bit null,


	ntb varchar(20) null,
	decripcion varchar(40) null,
	observacion varchar(240) null,
	activo bit null

)
