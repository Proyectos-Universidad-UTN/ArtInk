USE Artink
GO

DECLARE @NombreTabla VARCHAR(100) = 'dbo.Usuario'

EXECUTE dbo.GenerateInsert @ObjectName = @NombreTabla, @PopulateIdentityColumn = 1;