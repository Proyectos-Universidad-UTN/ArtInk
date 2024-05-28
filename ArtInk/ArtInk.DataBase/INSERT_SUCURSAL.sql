USE Artink 
GO

SET IDENTITY_INSERT Sucursal ON;

IF NOT EXISTS (SELECT 1 FROM Sucursal WHERE Id = 1)
BEGIN 
	INSERT INTO Sucursal (
       [Id]
      ,[Nombre]
      ,[Descripcion]
      ,[Telefono]
      ,[CorreoElectronico]
      ,[IdDistrito]
      ,[DireccionExacta]
      ,[FechaCreacion]
      ,[UsuarioCreacion])
    VALUES (
        1,
        'Jack Piercing',
        'Tatuajes y piercing',
        24305256,
        'jackpiercing@gmail.com',
        124,
        'Detrás del museo de Juan Santamaría',
        GETDATE (),
        'ArtInk'
    )
END

SET IDENTITY_INSERT Sucursal OFF;