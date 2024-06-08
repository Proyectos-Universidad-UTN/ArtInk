USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Provincia WHERE Id = 1)
BEGIN

SET IDENTITY_INSERT Provincia ON;

    INSERT INTO dbo.Provincia (Id, [Nombre])
    VALUES (1, N'San José'),
        (2, N'Alajuela'),
        (3, N'Cartago'),
        (4, N'Heredia'),
        (5, N'Guanacaste'),
        (6, N'Puntarenas'),
        (7, N'Limón')

    SET IDENTITY_INSERT Provincia OFF;

END