USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM DetalleFactura WHERE Id = 1)
BEGIN


	SET IDENTITY_INSERT dbo.DetalleFactura ON
	INSERT INTO dbo.DetalleFactura
	([Id],[IdFactura],[IdServicio],[NumeroLinea],[Cantidad],[TarifaServicio],[MontoSubtotal],[MontoImpuesto],[MontoTotal])
	VALUES
	(1,1,1,1,2,50.0000,100.0000,13.0000,113.0000)
	,(2,1,2,2,3,150.0000,450.0000,58.5000,508.5000)
	,(3,2,2,1,2,75.0000,150.0000,19.5000,169.5000)
	,(4,3,2,2,3,200.0000,600.0000,78.0000,678.0000)
	,(5,4,4,3,4,120.0000,480.0000,62.4000,542.4000)
	SET IDENTITY_INSERT dbo.DetalleFactura OFF;

END