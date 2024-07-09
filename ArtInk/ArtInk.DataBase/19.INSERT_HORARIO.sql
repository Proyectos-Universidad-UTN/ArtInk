USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM Horario WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Horario ON;

    INSERT INTO dbo.Horario
    (Id, [IdSucursal], [Dia], [HoraInicio], [HoraFin], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion])
    VALUES
    (1, 1, '2023-06-01', '10:00:00.0000000', '11:00:00.0000000', CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL),
    (2, 1, '2023-06-02', '11:00:00.0000000', '12:00:00.0000000', CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL),
    (3, 2, '2023-06-01', '12:00:00.0000000', '13:00:00.0000000', CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL),
    (4, 2, '2023-06-02', '13:00:00.0000000', '14:00:00.0000000', CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL),
    (5, 3, '2023-06-01', '14:00:00.0000000', '15:00:00.0000000', CONVERT(datetime, '2023-05-29 08:00:00.000', 121), 'admin', NULL, NULL);

    SET IDENTITY_INSERT Horario OFF;
END