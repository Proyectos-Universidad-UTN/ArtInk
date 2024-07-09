USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM UsuarioSucursal WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.UsuarioSucursal ON
	INSERT INTO dbo.UsuarioSucursal
	([Id],[IdUsuario],[IdSucursal])
	VALUES
	 (1,1,1)
	,(2,2,2)
	,(3,3,3)
	,(4,4,1)
	SET IDENTITY_INSERT dbo.UsuarioSucursal OFF;

END