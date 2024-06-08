USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM Servicio WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Servicio ON;

    INSERT INTO dbo.Servicio
    (Id, [Nombre], [Descripcion], [IdTipoServicio], [Tarifa], [Observacion], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion])
    VALUES
    (1, N'Tatuaje', N'Tatuaje minimalista', 2, 100.00, N'Con anestecia', 1, CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL),
    (2, N'Piercing', N'Perforacion en oreja derecha', 1, 150.00, N'Sin anestecia', 1, CONVERT(datetime, '2023-05-29 09:00:00.000', 121), 'admin', NULL, NULL),
    (3, N'Tatuaje', N'Tatuaje en hombro derecho', 2, 200.00, N'Con anestecia', 1, CONVERT(datetime, '2023-05-29 10:00:00.000', 121), 'admin', NULL, NULL),
    (4, N'Piercing', N'Perforacion de lengua', 1, 250.00, N'Sin anestecia', 1, CONVERT(datetime, '2023-05-29 11:00:00.000', 121), 'admin', NULL, NULL),
    (5, N'Tatuaje', N'Boceto del Rey Leon', 2, 300.00, N'Con anestecia', 1, CONVERT(datetime, '2023-05-29 12:00:00.000', 121), 'admin', NULL, NULL);

    SET IDENTITY_INSERT Servicio OFF;
END