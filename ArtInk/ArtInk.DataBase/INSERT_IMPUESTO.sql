USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Impuesto WHERE Id = 1)
BEGIN
	
	SET IDENTITY_INSERT dbo.Impuesto ON

	INSERT INTO dbo.Impuesto
	([Id],[Nombre],[Porcentaje])
	VALUES
	 (1,N'Impuesto sobre el Valor Agregado (IVA)',13.00)
	SET IDENTITY_INSERT dbo.Impuesto OFF;

END