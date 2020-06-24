ALTER TRIGGER [dbo].[DetalleOrdenIdentificador] ON [dbo].[DetalleOrden]
  AFTER INSERT
AS 
BEGIN
   --SET NOCOUNT ON agregado para evitar conjuntos de resultados adicionales
   -- interferir con las instrucciones SELECT.
  SET NOCOUNT ON;

  -- obtener el último valor de identificación del registro insertado o actualizado
  DECLARE @IDO INT, @mi_idorden INT
  SELECT @IDO = iddetalleorden, @mi_idorden=Orden_Id
  FROM INSERTED 

  -- Insertar declaraciones para desencadenar aquí
  Update DetalleOrden
  set identificador = concat((select codigoorden from Orden where idorden=@mi_idorden),'-', (select COUNT(seriehw) from DetalleOrden where Orden_Id=@mi_idorden AND estadodetalleorden=1 ))
	Where iddetalleorden=@IDO
END










SELECT O.codigoorden, o.cantidadhardware, count(do.seriehw) as MiDetalleOrden FROM DetalleOrden do inner join Orden o 
on do.Orden_Id=O.idorden WHERE do.estadodetalleorden=1
group by o.codigoorden, o.cantidadhardware 
go



SELECT O.codigoorden, o.cantidadhardware, o.produccion FROM DetalleOrden do inner join Orden o on do.Orden_Id=O.idorden WHERE do.estadodetalleorden=1
go


select * from DetalleOrden where estadodetalleorden=1
go