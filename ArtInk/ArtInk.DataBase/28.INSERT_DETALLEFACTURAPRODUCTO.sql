USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM DetalleFacturaProducto WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.DetalleFacturaProducto ON

	INSERT INTO dbo.DetalleFacturaProducto
	([Id],[IdDetalleFactura],[IdProducto],[Cantidad])
	VALUES
	 (1,1,1,1.00)
	SET IDENTITY_INSERT dbo.DetalleFacturaProducto OFF;
	
END