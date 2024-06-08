USE ARTINK
GO

IF NOT EXISTS(SELECT 1 FROM Contacto WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Contacto ON

	INSERT INTO dbo.Contacto
	([Id],[Nombre],[Apellidos],[Telefono],[CorreoElectronico],[IdProveedor],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModifiacion],[UsuarioModificacion])
	VALUES
	 (1,N'Juan',N'Pérez',12345678,N'juanperez@example.com',1,1,CONVERT(datetime,'2024-06-07 20:02:35.480',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(2,N'María',N'López',98765432,N'marialopez@example.com',2,1,CONVERT(datetime,'2024-06-07 20:02:35.480',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(3,N'Carlos',N'González',56789012,N'carlosgonzalez@example.com',3,1,CONVERT(datetime,'2024-06-07 20:02:35.480',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(4,N'Ana',N'Martínez',34567890,N'anamartinez@example.com',1,1,CONVERT(datetime,'2024-06-07 20:02:35.480',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Contacto OFF;

END
