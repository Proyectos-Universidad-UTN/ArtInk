USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Usuario WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT Usuario ON;

    INSERT INTO dbo.Usuario
    (Id, [Cedula],[Nombre],[Apellidos],[Telefono],[CorreoElectronico],[IdDistrito],[DireccionExacta],[FechaNacimiento],[Contrasenna],[IdGenero],[Activo],[UrlFoto],[IdRol],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
    VALUES
    (1, N'123456789',N'Pedro',N'Picapiedra',5551234,N'pedro.picapiedra@example.com',124,N'123 Calle Falsa, Piedradura',CONVERT(date,'1970-01-01',121),'12345',1,1,NULL,1,CONVERT(datetime,'2024-05-29 20:34:54.170',121),N'admin',CONVERT(datetime,NULL,121),NULL)
    ,(2, N'987654321',N'David',N'Soto',5554321,N'admin@example.com',124,N'456 Calle Administrativa',CONVERT(date,'1980-01-01',121),'12345',1,1,NULL,1,CONVERT(datetime,'2024-05-29 20:42:48.010',121),N'admin',CONVERT(datetime,NULL,121),NULL)
    ,(3, N'111222333',N'Megan',N'Azofeia',5551111,N'moderador@example.com',124,N'789 Calle Moderada',CONVERT(date,'1990-01-01',121),'12345',2,1,NULL,2,CONVERT(datetime,'2024-05-29 20:42:48.013',121),N'admin',CONVERT(datetime,NULL,121),NULL)
    ,(4, N'444555666',N'Usuario',N'ApellidoUser',5554444,N'usuario@example.com',124,N'101 Calle Usuario',CONVERT(date,'2000-01-01',121),'usuario123',1,1,NULL,3,CONVERT(datetime,'2024-05-29 20:42:48.013',121),N'admin',CONVERT(datetime,NULL,121),NULL)

    SET IDENTITY_INSERT Usuario OFF;

END