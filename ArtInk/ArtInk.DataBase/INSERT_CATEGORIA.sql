USE Artink 
GO

SET IDENTITY_INSERT Categoria ON;

INSERT INTO dbo.Categoria
(Id, [Codigo],[Nombre],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
VALUES
 (1, N'001',N'Tatuajes',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(2, N'002',N'Piercings de Oreja',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(3, N'003',N'Piercings de Nariz',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(4, N'004',N'Piercings de Cuerpo',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(5, N'005',N'Realismo',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(6, N'006',N'Blanco y Negro',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(7, N'007',N'Minimalista',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(8, N'008',N'Geométrico',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(9, N'009',N'Tradicionales',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(10, N'010',N'Acuarela',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(11, N'011',N'Tribal',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(12, N'012',N'Lettering',CONVERT(datetime,'2024-05-29 21:14:01.513',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)

SET IDENTITY_INSERT Categoria OFF;