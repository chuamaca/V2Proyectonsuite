alter proc RPT_GuiaRecepcion_SElect 
(
@iddetalle int
)
as
select o.empresaorden, emp.rucempresa, emp.dirempresa ,do.gremision, o.codigoorden, do.estadodetalleorden,
do.codigontb, do.seriehw, do.nmbrand, do.nmmodel, do.partnumberhw,  do.cableseg, do.maleta, do.mouse, do.accesorio
from orden o inner join detalleorden do
on  o.idorden = do.Orden_Id inner join Empresa emp 
on emp.nmempresa=o.empresaorden  where iddetalleorden = @iddetalle  
go

select * from DetalleOrden
go

-- Tabla detalleorden -> fechaemision para Guiade recepcion y guia de remision
--aDD .- dIRECCION DE RECEPCION DE EQUIPO, DEBE HABILITAR AL HACER SALIDA DE EQUIPO
-- Tabla DetalleOrden  -> Etsados:  1 = prod, 0= Salida , 2 = cambio