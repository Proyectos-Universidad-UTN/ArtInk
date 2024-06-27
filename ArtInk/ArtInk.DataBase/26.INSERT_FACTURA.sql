USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Factura WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Factura ON

	INSERT INTO dbo.Factura
	([Id],[IdCliente],[NombreCliente],[Fecha],[IdTipoPago],[Consecutivo],[IdUsuarioSucursal],[IdImpuesto],[PorcentajeImpuesto],[SubTotal],[MontoImpuesto],[MontoTotal],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,1,N'Nombre Cliente',CONVERT(date,'2024-06-08',121),1,1001,1,1,13.00,550.0000,71.5000,621.5000,CONVERT(datetime,'2024-06-09 00:50:02.180',121),N'Usuario',CONVERT(datetime,NULL,121),NULL)
	,(2,1,N'Contado',CONVERT(date,'2024-06-10',121),1,1002,1,1,13.00,600.0000,90.0000,690.0000,CONVERT(datetime,'2024-06-10 14:30:00.000',121),N'Usuario2',CONVERT(datetime,NULL,121),NULL)
	,(3,1,N'Contado',CONVERT(date,'2024-06-15',121),1,1003,1,1,13.00,700.0000,80.0000,710.0000,CONVERT(datetime,'2024-06-10 14:30:00.000',121),N'Usuario1',CONVERT(datetime,NULL,121),NULL)
	,(4,1,N'Contado',CONVERT(date,'2024-06-09',121),1,1004,1,1,13.00,1000.0000,90.0000,1090.0000,CONVERT(datetime,'2024-06-10 14:30:00.000',121),N'Usuario1',CONVERT(datetime,NULL,121),NULL)
	,(5,1,N'Contado',CONVERT(date,'2024-06-08',121),1,1005,1,1,13.00,15000.0000,160.0000,1590.0000,CONVERT(datetime,'2024-06-10 14:30:00.000',121),N'Usuario1',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Factura OFF;
END
