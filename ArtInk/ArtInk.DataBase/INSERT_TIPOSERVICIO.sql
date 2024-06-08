USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM TipoServicio WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT TipoServicio ON;

    INSERT INTO dbo.TipoServicio
    (Id, [Nombre],[Duracion])
    VALUES
    (1, N'Piercing','01:00:00')
    ,(2, N'Tatuaje','01:00:00')
   

    SET IDENTITY_INSERT TipoServicio OFF;

END