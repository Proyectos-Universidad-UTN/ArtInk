USE Artink 
GO

SET IDENTITY_INSERT Genero ON;

INSERT INTO dbo.Genero
(Id, [Nombre])
VALUES
 (1, N'Masculino')
,(2, N'Femenino')
,(3, N'No definido')

SET IDENTITY_INSERT Genero OFF;