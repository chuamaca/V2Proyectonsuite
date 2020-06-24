--REPORTE PARA VISTA DE CLIENTES

create proc RPT_Hardware_produccion_for_empresa
@empresa varchar(100)
AS
select  (select count(seriehw)  from DetalleOrden do inner join Orden o on do.Orden_Id=o.idorden 
inner join Empresa e on e.nmempresa=o.empresaorden
where do.estadodetalleorden=1 and o.empresaorden=@empresa) AS hardwareprodempresa, 


(select count(seriehw)  from DetalleOrden do inner join Orden o on do.Orden_Id=o.idorden 
inner join Empresa e on e.nmempresa=o.empresaorden
where do.estadodetalleorden=0 and o.empresaorden=@empresa) AS hardwareclose ,

(select count(seriehw)  from DetalleOrden do inner join Orden o on do.Orden_Id=o.idorden 
inner join Empresa e on e.nmempresa=o.empresaorden
where do.estadodetalleorden=2 and o.empresaorden=@empresa ) AS hardwarecamvioempresa ,

(select count(produccion)  from Orden where produccion = 0 and estadoorden =1   and  empresaorden = @empresa ) AS sinatencionempresa
go
