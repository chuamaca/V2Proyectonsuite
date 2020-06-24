

alter procedure [dbo].[RRR_insert_facturacion]
as
DECLARE @Number varchar(20);  
DECLARE @mescom varchar(20);
--OBTENEMOS EL MES AY ANNO ACTUAL maR-20
SET @Number = concat(SUBSTRING(DATENAME(mm, DATEADD(mm, 0, GETDATE())),1,3) ,'-', Substring(DATENAME(YY, DATEADD(YY, 0, GETDATE())),3,2));

--EXTRAEMOS EL ULTIMOS MES REGISTRADO EN LAS LIQUIDACIONES
SET @mescom = (select referencia from LiquidacionFacturacion where idLiquidacionesFacturacion= (Select max(idLiquidacionesFacturacion) from LiquidacionFacturacion))

-- EVALUAMOS SI YA ESTA REGISTADO
IF @Number != @mescom
  INSERT INTO LiquidacionFacturacion

SELECT 
		procesos,
		estado,
		contratointerno,
		refacturable,
		mes,
		referencia,
		doc,
		numerodocumento,
		c_fact,
		fechaemision,
		fechainicio,
		fechafin,
		credito,
		rucempresa,
		empresa,
		contratomarco,
		grupoeconomico,
		ubicacion,
		red,
		responsable,
		telefonoresponsable,
		sucursal,
		ruccliente,
		cliente,
		usuariofinal,
		telefonousuario,
		tipousuario,
		ordenservicio,
		fechaordenservicio,
		rqcliente,
		contrato,
		guiaremision,
		tipo,
		tipohardwareestado,
		descripciontipohardwareestado,
		codigoequipo,
		tipoequipo,
		serie,
		marca,
		modelo,
		parnumber,
		bateria,
		cargador,
		procesador,
		velocidad,
		ram,
		disco,
		licencia,
		nombreequipo,
		usuariooficce,
		cableseguridad,
		mouse,
		maletin,
		softwareadicional,
		accesorios,
		observaciones,
		moneda,
		valor,
		igv,
		total,
		sefacturo,
		identificador
		FROM Liquidacion where sefacturo='SI' and referencia=@Number
go