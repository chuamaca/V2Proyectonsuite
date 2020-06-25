USE [InventoryAGr]
GO
/****** Object:  Trigger [dbo].[EstadoHardwareAdd]    Script Date: 12/01/2020 05:48:23 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter TRIGGER [dbo].[DetalleOrdenProduccion] ON [dbo].[DetalleOrden]
  AFTER INSERT, update
AS 
BEGIN
   --SET NOCOUNT ON agregado para evitar conjuntos de resultados adicionales
   -- interferir con las instrucciones SELECT.
  SET NOCOUNT ON;

  -- obtener el último valor de identificación del registro insertado o actualizado
  DECLARE @IDO INT, @idprod INT
  SELECT @IDO = iddetalleorden,  @idprod = Orden_Id
  FROM INSERTED 

  -- Insertar declaraciones para desencadenar aquí
UPDATE Orden 
 set produccion = (select(count(estadodetalleorden)) from DetalleOrden where estadodetalleorden=1 AND  Orden_ID = @idprod )
  
  WHERE 
		idorden=@idprod

END