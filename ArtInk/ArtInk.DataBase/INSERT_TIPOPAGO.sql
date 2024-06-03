USE Artink 
GO

SET IDENTITY_INSERT TipoPago ON;

INSERT INTO dbo.TipoPago
(Id, [Descripcion],[Referencia])
VALUES
 (1, N'Transferencia',1)
,(2, N'Efectivo',2)
,(3, N'SINPE',3)

SET IDENTITY_INSERT TipoPago OFF;