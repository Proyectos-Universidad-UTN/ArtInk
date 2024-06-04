USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM UnidadMedida WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT UnidadMedida ON;

    INSERT INTO dbo.UnidadMedida
    (Id, [Nombre],[Simbolo])
    VALUES
    (1, N'Kilogramos',N'kg   ')
    ,(2, N'Metros',N'm    ')
    ,(3, N'Unidad',N'u    ')
    ,(4, N'Caja',N'caja ')

    SET IDENTITY_INSERT UnidadMedida OFF;

END