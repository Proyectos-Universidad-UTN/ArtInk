USE Artink
GO

DECLARE @NombreTabla VARCHAR(100) = 'dbo.DetalleFacturaProducto'

EXECUTE dbo.GenerateInsert @ObjectName = @NombreTabla, @PopulateIdentityColumn = 1;