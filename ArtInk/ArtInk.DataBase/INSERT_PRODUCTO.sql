USE Artink 
GO

SET IDENTITY_INSERT Producto ON;

INSERT INTO dbo.Producto
(Id, [Nombre],[Descripcion],[Marca],[IdCategoria],[Costo],[SKU],[Cantidad],[IdUnidadMedida],[Activo],[FechaCreacion],[UsuarioCreacion],[FechaModificacion],[UsuarioModificacion])
VALUES
 (1, N'Piercing Oreja Acero Quirúrgico',N'Piercing de oreja hecho de acero quirúrgico',N'Jack Piercing',2,15.0000,N'PIE001',20,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(2, N'Piercing Nariz Titanio',N'Piercing nasal hecho de titanio',N'Jack Piercing',3,20.0000,N'PIE002',18,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(3, N'Piercing Labio Acero Inoxidable',N'Piercing para el labio hecho de acero inoxidable',N'Jack Piercing',4,18.0000,N'PIE003',15,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(4, N'Piercing Ceja Plata',N'Piercing para la ceja hecho de plata',N'Jack Piercing',5,25.0000,N'PIE004',10,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(5, N'Piercing Ombligo Titanio',N'Piercing para el ombligo hecho de titanio',N'Jack Piercing',6,22.0000,N'PIE005',12,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)
,(6, N'Piercing Labret Acrílico',N'Piercing labret hecho de acrílico',N'Jack Piercing',7,12.0000,N'PIE006',20,4,1,CONVERT(datetime,'2024-05-29 21:16:44.357',121),N'Administrador',CONVERT(datetime,NULL,121),NULL)

SET IDENTITY_INSERT Producto OFF;