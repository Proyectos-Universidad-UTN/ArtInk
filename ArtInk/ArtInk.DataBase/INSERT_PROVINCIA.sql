USE Artink 
GO

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