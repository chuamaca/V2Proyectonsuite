create procedure RPT_Nsuite_Gremision
(
@idorden int
)
as
Select o.idorden,  o.numeroorden,  o.codigoorden, o.empresaorden, e.rucempresa,  e.dirempresa , 
o.ordenservicio, o.rqservicio, o.motivorenting,o.contratomarco,  o.rentinginicio, o.rentingfin,
o.hardwaredevice, o.cantidadhardware, o.tipohardware,  o.estadoorden, o.generateuserorden, DO.codigontb, 
do.seriehw, do.nmbrand, do.nmmodel, do.partnumberhw,  do.snbatery,do.sncharger, do.nmprocessor,
do.ghzprocessor, do.mcapacity, do.capacitystorage, DO.lic, DO.nmequipo,do.cableseg, do.mouse, do.maleta,
do.gremision, DO.fregistro
FROM Orden o inner join Empresa e
on o.empresaorden= e.nmempresa inner join Cliente c
on o.clienteorden=c.nmcliente inner join DetalleOrden do
on o.idorden=do.Orden_Id where idorden=@idorden and do.estadodetalleorden=1
go





select * from statusdevice
go

select * from hardware where seriehw='J2R5DT2'
go


select * from Orden
go

