USE [InventoryAGr]
GO
/****** Object:  StoredProcedure [dbo].[RRR_insert_liquidacion]    Script Date: 04/04/2020 01:02:34 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[RRR_insert_liquidacion]
as
DECLARE @Number varchar(20);  
DECLARE @mescom varchar(20);
--OBTENEMOS EL MES AY ANNO ACTUAL maR-20
SET @Number = concat(SUBSTRING(DATENAME(mm, DATEADD(mm, 0, GETDATE())),1,3) ,'-', Substring(DATENAME(YY, DATEADD(YY, 0, GETDATE())),3,2));

--EXTRAEMOS EL ULTIMOS MES REGISTRADO EN LAS LIQUIDACIONES
SET @mescom = (select referencia from Liquidacion where idLiquidaciones= (Select max(idLiquidaciones) from Liquidacion))

-- EVALUAMOS SI YA ESTA REGISTADO
IF @Number != @mescom
  INSERT INTO Liquidacion
	SELECT 
	o.codigoorden AS procesos, 
	dt.estadodetalleorden AS estado, 
	o.contratointernoorden AS contratointerno,
	o.refacturableorden AS refacturable, 
	/* REF*/
	( month(convert(date, GETDATE())) + 1) - month(TRY_CONVERT(date, rentinginicio, 103))  as mes,
	concat(SUBSTRING(DATENAME(mm, DATEADD(mm, 0, GETDATE())),1,3)  ,'-', Substring(DATENAME(YY, DATEADD(YY, 0, GETDATE())),3,2)) AS referencia,
	/* FIN REF*/
	'' AS doc,
	o.factura AS numerodocumento,
	'' AS c_fact,
	o.ftemision as fechaemision,
	o.rentinginicio AS fechainicio,
	o.rentingfin AS fechafin,
	'30' AS credito,
	emp.rucempresa AS rucempresa,
	o.empresaorden AS empresa,
	--COLUNNA ADD
	o.contratomarco as contratomarco,
	o.grupoeconomico as grupoeconomico,
	dt.ubicacion as ubicacion,
	o.redequipoorden as red,
	o.responsableorden AS responsable,
		--COLUNNA ADD
	o.telefonoresponsableorden as telefonoresponsable,
	
	o.sucursalorden AS sucursal,
	cli.ruccliente AS ruccliente,
	cli.nmcliente AS cliente,
	dt.usuariof AS usuariofinal,
	--COLUNNA ADD
	dt.telefonof as telefonousuario,
	
	o.tipousuarioorden AS tipousuario,
	o.ordenservicio AS ordenservicio,
	o.fentregaorden AS fechaordenservicio,
	o.rqservicio AS rqcliente,
	o.contratointernoorden AS contrato, 
	dt.gremision AS guiaremision,
	o.tipohardware AS tipo,
	dt.tipohardwareestado AS tipohardwareestado,
	dt.descripciontipohardwareestado AS descripciontipohardwareestado,
	dt.codigontb AS codigoequipo,
	dt.typedevice AS tipoequipo,
	dt.seriehw AS serie,
	dt.nmbrand AS marca,
	dt.nmmodel AS modelo,
	dt.partnumberhw AS parnumber,
	dt.snbatery AS bateria,
	dt.sncharger AS cargador,
	dt.nmprocessor AS procesador,
	dt.ghzprocessor AS velocidad,
	dt.mcapacity AS ram,
	dt.capacitystorage AS disco,
	dt.lic AS licencia,
	dt.nmequipo AS nombreequipo,
	'' as usuariooficce,
	dt.cableseg  AS cableseguridad,
	dt.mouse AS mouse ,
	dt.maleta AS maletin,
	o.sofwareorden AS softwareadicional,
	dt.accesorio AS accesorios,
	dt.obscambio AS observaciones,
	dt.moneda AS moneda,
	dt.valor AS valor, 
	dt.IGV  AS igv,
	dt.total AS total,
	dt.sefacturo AS sefacturo,
	dt.identificador as identificador
	FROM Orden o
	INNER JOIN DetalleOrden dt
	ON o.idorden = dt.Orden_Id
	INNER JOIN empresa emp
	ON emp.nmempresa = o.empresaorden
	INNER JOIN Cliente cli
	ON cli.nmcliente = o.clienteorden
	Where dt.sefacturo <> 'no' and (dt.estadodetalleorden = '0' or dt.estadodetalleorden = '1')

