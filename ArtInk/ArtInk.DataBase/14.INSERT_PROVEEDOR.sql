USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Proveedor WHERE Id = 1)
BEGIN	
	
	SET IDENTITY_INSERT dbo.Proveedor ON

	INSERT INTO dbo.Proveedor
	([Id],[Nombre],[CedulaJuridica],[RasonSocial],[Telefono],[CorreoElectronico],[IdDistrito],[DireccionExacta],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,N'Proveedor A',N'123456789',N'Razón Social A',12345678,N'proveedora@example.com',1,N'Dirección Exacta A',1,CONVERT(datetime,'2024-06-07 19:52:14.937',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(2,N'Proveedor B',N'987654321',N'Razón Social B',87654321,N'proveedorb@example.com',2,N'Dirección Exacta B',1,CONVERT(datetime,'2024-06-07 19:52:14.937',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(3,N'Proveedor C',N'456789123',N'Razón Social C',56789012,N'proveedorc@example.com',3,N'Dirección Exacta C',1,CONVERT(datetime,'2024-06-07 19:52:14.937',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Proveedor OFF;

END