create proc RPT_Orden_select
(
@idorden int
)
as
Select  numeroorden, idorden,  codigoorden, empresaorden, sucursalorden, clienteorden, contratointernoorden, refacturableorden, generateuserorden,
generateempresaorden, fsolicitudorden, fentregaorden, responsableorden, telefonoresponsableorden, tipousuarioorden, equipousuarioorden,
telefonousuarioorden, redequipoorden, ubicacionequipoorden, Observacionesorden, ordenservicio, rqservicio, adjuntoorden, aprobadorrq,
correoaprobador, motivorenting, contratomarco, tipocliente, grupoeconomico, rentinginicio, rentingfin, hardwaredevice, cantidadhardware,
tipohardware, sofwareorden, estadoorden, tipoatencionorden
FROM Orden where idorden=@idorden
go
