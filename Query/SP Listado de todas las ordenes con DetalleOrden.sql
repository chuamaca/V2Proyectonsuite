Select  o.numeroorden, o.idorden,  o.codigoorden, o.empresaorden, o.sucursalorden, o.clienteorden, o.contratointernoorden, o.refacturableorden, o.generateuserorden,
o.generateempresaorden, o.fsolicitudorden, o.fentregaorden, o.responsableorden, o.telefonoresponsableorden, o.tipousuarioorden, o.equipousuarioorden,
o.telefonousuarioorden, o.redequipoorden, o.ubicacionequipoorden, o.Observacionesorden, o.ordenservicio, o.rqservicio, o.adjuntoorden, o.aprobadorrq,
o.correoaprobador, o.motivorenting, o.contratomarco, o.tipocliente, o.grupoeconomico, o.rentinginicio, o.rentingfin, o.hardwaredevice, o.cantidadhardware,
o.tipohardware, o.sofwareorden, o.estadoorden, o.tipoatencionorden, 
hw.codigontb, hw.typedevice,  hw.seriehw, br.nmbrand ,ml.nmmodel, hw.partnumberhw, hwd.snbatery, hwd.sncharger,      pro.nmprocessor , pro.ghzprocessor,
 mry.mcapacity, stg.capacitystorage, 'WINDOWS 10/OFFICE' as lic , hw.nmequipo,

do.iddetalleorden, do.Orden_Id, do.Hardware_Id, do.seriedt, do.usuariof, do.telefonof, do.ubicacion, do.cableseg, do.mouse, do.maleta, do.accesorio,
do.valor, do.IGV, do.total, do.obscambio, do.estadodetalleorden

FROM 
Orden o inner join DetalleOrden do
on o.idorden=do.Orden_Id inner join hardware hw 
on  hw.idhw=do.Hardware_Id inner join device dvc
on hw.iddevice=dvc.iddevice inner join brand br
on hw.idbrand=br.idbrand inner join model ml
on hw.idmodel=ml.idmodel inner join hardwaredetail hwd
on hw.iddetailhw=hwd.iddetailehw inner join statusdevice stdvc
on hw.idstatusdevice=stdvc.idstatusdevice inner join processor pro
on hwd.idprocessor=pro.idprocessor inner join memory mry
on hwd.idmemory=mry.idmemory inner join storage stg
on hwd.idstorage=stg.idstorage 







