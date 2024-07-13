USE Artink;
GO

IF NOT EXISTS (SELECT 1 FROM Reserva WHERE Id = 1)
BEGIN
    SET IDENTITY_INSERT dbo.Reserva ON
    
    INSERT INTO dbo.Reserva
    ([Id],[Fecha],[Hora],[Estado],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion],[IdUsuarioSucursal],[IdSucursal])
    VALUES
    (1,CONVERT(date,'2023-06-01',121),CONVERT(time,'10:00:00.0000000',121),'P',1,CONVERT(datetime,'2023-06-01 09:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,1,1)
    ,(2,CONVERT(date,'2023-06-02',121),CONVERT(time,'11:00:00.0000000',121),'P',1,CONVERT(datetime,'2023-06-02 10:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,2,2)
    ,(3,CONVERT(date,'2023-06-03',121),CONVERT(time,'12:00:00.0000000',121),'P',1,CONVERT(datetime,'2023-06-03 11:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,3,3)
    ,(4,CONVERT(date,'2023-06-04',121),CONVERT(time,'13:00:00.0000000',121),'P',1,CONVERT(datetime,'2023-06-04 12:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,1,1)
    ,(5,CONVERT(date,'2023-06-05',121),CONVERT(time,'14:00:00.0000000',121),'P',1,CONVERT(datetime,'2023-06-05 13:00:00.000',121),N'admin',CONVERT(datetime,NULL,121),NULL,2,2)

    SET IDENTITY_INSERT dbo.Reserva OFF
END