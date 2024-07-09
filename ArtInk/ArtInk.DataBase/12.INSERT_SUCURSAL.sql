USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Sucursal WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT Sucursal ON;

    INSERT INTO dbo.Sucursal
        (Id, [Nombre],[Descripcion],[Telefono],[CorreoElectronico],[IdDistrito],[DireccionExacta],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
        VALUES
        (1, N'Jack Piercing',N'Tatuajes y piercing',24305256,N'jackpiercing@gmail.com',124,N'Detrás del museo de Juan Santamaría',1,CONVERT(datetime,'2024-05-27 22:53:12.237',121),N'ArtInk',CONVERT(datetime,NULL,121),NULL)
        ,(2, N'Jack Piercing',N'Sucursal Jack Piercing',5551234,N'info@jackpiercing.com',124,N'123 Calle Piercing',1,CONVERT(datetime,'2024-05-29 21:01:36.953',121),N'admin',CONVERT(datetime,NULL,121),NULL)
        ,(3, N'Jack Tatuajes',N'DTatuajes and Piercing',5559876,N'info@sucursal.com',12,N'123 Calle Sucursal',1,CONVERT(datetime,'2024-05-29 21:04:23.297',121),N'admin',CONVERT(datetime,NULL,121),NULL)

    SET IDENTITY_INSERT Sucursal OFF;

END