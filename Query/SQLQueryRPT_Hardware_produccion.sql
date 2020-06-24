--create proc RPT_Hardware_produccion
--as
--select count(seriehw) as hardwareprod from DetalleOrden
--where estadodetalleorden=1
--go




alter proc RPT_Hardware_produccion
AS
select  (select count(seriehw)  from DetalleOrden where estadodetalleorden=1) AS hardwareprod, 
(select count(seriehw)  from DetalleOrden where estadodetalleorden=0) AS hardwareclose ,
(select count(seriehw)  from DetalleOrden where estadodetalleorden=2) AS hardwarecambio ,

(select count(seriehw)  from hardware where idstatusdevice=1) AS warehousehw,
(select count(produccion)  from Orden where produccion =0 and estadoorden =1) AS sinatencion





