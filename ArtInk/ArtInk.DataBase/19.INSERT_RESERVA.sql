USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM Reserva WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT Reserva ON;

    INSERT INTO dbo.Reserva
    (Id, [Fecha], [Hora], [IdSucursalHorario], [Estado], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [IdUsuarioSucursal])
    VALUES
    (1, '2023-06-01', '10:00:00.0000000', 1, 'P', 1, CONVERT(datetime, '2023-06-01 09:00:00.000', 121), 'admin', NULL, NULL,1),
    (2, '2023-06-02', '11:00:00.0000000', 2, 'P', 1, CONVERT(datetime, '2023-06-02 10:00:00.000', 121), 'admin', NULL, NULL,1),
    (3, '2023-06-03', '12:00:00.0000000', 3, 'P', 1, CONVERT(datetime, '2023-06-03 11:00:00.000', 121), 'admin', NULL, NULL,1),
    (4, '2023-06-04', '13:00:00.0000000', 4, 'P', 1, CONVERT(datetime, '2023-06-04 12:00:00.000', 121), 'admin', NULL, NULL,1),
    (5, '2023-06-05', '14:00:00.0000000', 5, 'P', 1, CONVERT(datetime, '2023-06-05 13:00:00.000', 121), 'admin', NULL, NULL,3);

    SET IDENTITY_INSERT Reserva OFF;
END