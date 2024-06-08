USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Rol WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT Rol ON;

    INSERT INTO dbo.Rol
    (Id, [Descripcion],[Tipo],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
    VALUES
    (1, N'Administrador',N'Interno',1,CONVERT(datetime,'2024-05-29 19:42:03.213',121),N'usuario_admin',CONVERT(datetime,NULL,121),NULL)
    ,(2, N'Usuario',N'Externo',1,CONVERT(datetime,'2024-05-29 19:42:03.213',121),N'usuario_admin',CONVERT(datetime,NULL,121),NULL)
    ,(3, N'Moderador',N'Interno',1,CONVERT(datetime,'2024-05-29 19:42:03.213',121),N'usuario_admin',CONVERT(datetime,NULL,121),NULL)
    ,(4, N'Invitado',N'Externo',1,CONVERT(datetime,'2024-05-29 19:42:03.213',121),N'usuario_admin',CONVERT(datetime,NULL,121),NULL)

    SET IDENTITY_INSERT Rol OFF;

END