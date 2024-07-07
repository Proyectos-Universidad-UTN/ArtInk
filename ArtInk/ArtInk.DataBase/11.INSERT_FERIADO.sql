USE Artink
GO

IF NOT EXISTS(SELECT 1 FROM Feriado WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Feriado ON

	INSERT INTO dbo.Feriado
	([Id],[Nombre],[Mes],[Dia],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,N'Año Nuevo','Enero', 1, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(2,N'Jueves Santo','Marzo', 28, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(3,N'Viernes Santo','Marzo', 29, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(4,N'Día de Juan Santamaría', 'Abril', 11, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(5,N'Día de la Independencia', 'Septiembre', 15, CONVERT(date,'2024-09-15',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(6,N'Día de las Culturas', 'Octubre', 12, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(7,N'Día de la Abolición del Ejército','Diciembre', 1, 1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(8,N'Navidad','Diciembre', 25, CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Feriado OFF;

END
