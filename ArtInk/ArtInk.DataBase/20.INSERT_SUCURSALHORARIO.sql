USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM SucursalHorario WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT SucursalHorario ON;

    INSERT INTO dbo.SucursalHorario
    (Id, [IdSucursal], [IdHorario])
    VALUES
    (1, 1, 1),
    (2, 2, 2),
    (3, 3, 3),
    (4, 1, 4),
    (5, 2, 5);

    SET IDENTITY_INSERT SucursalHorario OFF;
END