USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM ReservaServicio WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT ReservaServicio ON;

    INSERT INTO dbo.ReservaServicio
    (Id, [IdReserva], [IdServicio])
    VALUES
    (1, 1, 1),
    (2, 1, 2),
    (3, 2, 3),
    (4, 3, 1),
    (5, 4, 2);

    SET IDENTITY_INSERT ReservaServicio OFF;
END
