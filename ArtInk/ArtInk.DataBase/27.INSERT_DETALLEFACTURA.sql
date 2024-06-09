USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM DetalleFactura WHERE Id = 1)
BEGIN
	
	SET IDENTITY_INSERT dbo.DetalleFactura ON

	INSERT INTO dbo.DetalleFactura
	([Id],[IdFactura],[IdServicio],[NumeroLinea],[Cantidad],[TarifaServicio],[MontoSubtotal],[MontoImpuesto],[MontoTotal])
	VALUES
	 (1,1,1,1,2,50.0000,100.0000,13.0000,113.0000)
	SET IDENTITY_INSERT dbo.DetalleFactura OFF;
END