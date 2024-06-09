USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Factura WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Factura ON

	INSERT INTO dbo.Factura
	([Id],[IdCliente],[NombreCliente],[Fecha],[IdTipoPago],[Consecutivo],[IdUsuarioSucursal],[IdImpuesto],[PorcentajeImpuesto],[SubTotal],[MontoImpuesto],[MontoTotal],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,1,N'Nombre Cliente',CONVERT(date,'2024-06-08',121),1,1001,1,1,13.00,100.0000,13.0000,113.0000,CONVERT(datetime,'2024-06-09 00:50:02.180',121),N'Usuario',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Factura OFF;
END

