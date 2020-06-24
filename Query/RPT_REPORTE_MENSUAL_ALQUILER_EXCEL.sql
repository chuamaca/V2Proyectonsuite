-- EL ESTADO TIENE QUE ESTAR EN RPODUCCION ES DECIR ESTADO 1

--C.FACT, F. REC. CRED, F.VENC

Select   o.codigoorden AS PROCESO, 'PRODUCCION' AS ESTADO,o.contratointernoorden AS 'CONT.INT.ADE' , o.refacturableorden AS REFACTURABLE,
'1' AS MES, 'Ene-20' as MES, 'FAC'  AS DOC, O.factura as NUM_DOC, '' AS 'C.FACT' , o.ftemision as 'F.EMI', '' AS 'F.REC',  o.rentinginicio AS 'PER.FACT.INI', o.rentingfin AS 'PER.FACT.FIN',
'30' AS CRED, '' AS 'F.VENC', '' AS 'F.PAGO', '' AS 'CON.PAG' , E.rucempresa AS RUC, o.empresaorden AS CLIENTE, o.responsableorden AS 'RESP.CLI'




--, o.sucursalorden, o.clienteorden,   o.generateuserorden,
--o.generateempresaorden, o.fsolicitudorden, o.fentregaorden,  o.telefonoresponsableorden, o.tipousuarioorden, o.equipousuarioorden,
--o.telefonousuarioorden, o.redequipoorden, o.ubicacionequipoorden, o.Observacionesorden, o.ordenservicio, o.rqservicio, o.adjuntoorden, o.aprobadorrq,
--o.correoaprobador, o.motivorenting, o.contratomarco, o.tipocliente, o.grupoeconomico, o.hardwaredevice, o.cantidadhardware,
--o.tipohardware, o.sofwareorden, o.estadoorden, o.tipoatencionorden, 
--hw.codigontb, hw.typedevice,  hw.seriehw, br.nmbrand ,ml.nmmodel, hw.partnumberhw, hwd.snbatery, hwd.sncharger,      pro.nmprocessor , pro.ghzprocessor,
-- mry.mcapacity, stg.capacitystorage, 'WINDOWS 10/OFFICE' as lic , hw.nmequipo,

--do.iddetalleorden, do.Orden_Id, do.Hardware_Id, do.seriedt, do.usuariof, do.telefonof, do.ubicacion, do.cableseg, do.mouse, do.maleta, do.accesorio,
--do.valor, do.IGV, do.total, do.obscambio, do.estadodetalleorden

FROM 
Orden o inner join DetalleOrden do
on o.idorden=do.Orden_Id inner join Empresa e
on o.empresaorden= e.nmempresa inner join Sucursal suc
on suc.empresa_id=e.idempresa  inner join Cliente c
on o.clienteorden=c.nmcliente  INNER JOIN hardware hw 
on  hw.idhw=do.Hardware_Id inner join device dvc
on hw.iddevice=dvc.iddevice inner join brand br
on hw.idbrand=br.idbrand inner join model ml
on hw.idmodel=ml.idmodel inner join hardwaredetail hwd
on hw.iddetailhw=hwd.iddetailehw inner join statusdevice stdvc
on hw.idstatusdevice=stdvc.idstatusdevice inner join processor pro
on hwd.idprocessor=pro.idprocessor inner join memory mry
on hwd.idmemory=mry.idmemory inner join storage stg
on hwd.idstorage=stg.idstorage 



WHERE O.estadoorden=1





