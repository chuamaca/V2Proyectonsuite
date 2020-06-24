-- PAS O1:RENOBRAR  la Tabla HARDWARE EN ÑLA BSE INVENTARIO POR QUE VINCULAREMOS CON LA MIGRACION QUE VA A REALIZAR DESDE EL PROGRAMA.

-- PASO 02: Una vez migrado, reasignar las key de la tabla HARDWARE Y DETALLEORDEN.

-- debemos activar la creacion de diagramas 
/**

Alter authorization on database::InventoryAGr to sa
*/
-- PASO 3. DEBEMOS Quitarlas relaciones de Entre Hardware y DetalleOrdne
--PASO 4. Debemos realcionar con la nueva tabla de Hardware_ con DetalleORden
-- PASO 5. enobrabr de nuevo la tabla HARDWARE_ A HARDWARE.

-- Listo solo tenemos que correr los triguers y los procedmientos almacenados.
	-- [SP_NSUITE_hardware_Select]
	--  triggers [DetalleOrdenProduccion]
	-- [EstadoHardwareAdd]
	-- [EstadoHardwareRemove]
	-- [IGV_TOTAL]







