USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Cliente WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Cliente ON

	INSERT INTO dbo.Cliente
	([Id],[Nombre],[Apellidos],[CorreoElectronico],[Telefono],[IdDistrito],[DireccionExacta],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,N'Contado',N'-',N'123456@example.com',12345678,1,N'Calle 1, Ciudad',1,CONVERT(datetime,'2024-06-07 18:18:34.970',121),N'admin',CONVERT(datetime,'2024-06-07 18:18:34.970',121),N'admin')
	SET IDENTITY_INSERT dbo.Cliente OFF;

END