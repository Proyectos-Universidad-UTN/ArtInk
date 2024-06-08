USE Artink
GO

IF NOT EXISTS(SELECT 1 FROM Feriado WHERE Id = 1)
BEGIN

	SET IDENTITY_INSERT dbo.Feriado ON

	INSERT INTO dbo.Feriado
	([Id],[Nombre],[Fecha],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
	VALUES
	 (1,N'Año Nuevo',CONVERT(date,'2024-01-01',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(2,N'Jueves Santo',CONVERT(date,'2024-04-04',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(3,N'Viernes Santo',CONVERT(date,'2024-04-05',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(4,N'Día de Juan Santamaría',CONVERT(date,'2024-04-11',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(5,N'Día de la Independencia',CONVERT(date,'2024-09-15',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(6,N'Día de las Culturas',CONVERT(date,'2024-10-12',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(7,N'Día de la Abolición del Ejército',CONVERT(date,'2024-12-01',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	,(8,N'Navidad',CONVERT(date,'2024-12-25',121),1,CONVERT(datetime,'2024-06-07 19:07:58.183',121),N'admin',CONVERT(datetime,NULL,121),NULL)
	SET IDENTITY_INSERT dbo.Feriado OFF;

END
