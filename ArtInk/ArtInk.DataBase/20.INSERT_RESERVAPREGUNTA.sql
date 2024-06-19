USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM ReservaPregunta WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT ReservaPregunta ON;

    INSERT INTO dbo.ReservaPregunta
    (Id, [IdReserva], [Pregunta], [Activo], [FechaCreacion], [UsuarioCreacion], [FechaModificacion], [UsuarioModificacion], [Respuesta])
    VALUES
     (1,1,N'¿Cuál es el propósito de su visita?',1,CONVERT(datetime,'2023-05-29 08:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,N'Realizarme un Piercing y tatuaje')
    ,(2,1,N'¿Tiene alguna alergia conocida?',1,CONVERT(datetime,'2023-05-29 08:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,N'No tengo ninguna Alergia')
    ,(3,2,N'¿Prefiere alguna hora específica?',1,CONVERT(datetime,'2023-05-29 08:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,N'La hora que guste esta bien, no tengo problema')
    ,(4,2,N'¿Necesita asistencia especial?',1,CONVERT(datetime,'2023-05-29 08:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,N'Unicamente anesticia por favor')
    ,(5,3,N'¿Tiene alguna preferencia de habitación?',1,CONVERT(datetime,'2023-05-29 08:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,N'Me gustaria recibir el servicion en la habitacion 2')

    SET IDENTITY_INSERT ReservaPregunta OFF;
END
