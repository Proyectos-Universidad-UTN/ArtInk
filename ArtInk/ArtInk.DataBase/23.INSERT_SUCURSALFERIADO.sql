﻿USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM SucursalFeriado WHERE Id = 1)
BEGIN
	SET IDENTITY_INSERT dbo.SucursalFeriado ON

	INSERT INTO dbo.SucursalFeriado
	([Id],[IdFeriado],[IdSucursal])
	VALUES
	 (1,1,1)
	,(2,2,1)
	,(3,3,1)
	,(4,4,1)
	,(5,5,1)
	,(6,6,1)
	,(7,7,1)
	,(8,8,1)
	,(9,1,2)
	,(10,2,2)
	,(11,3,2)
	,(12,4,2)
	,(13,5,2)
	,(14,6,2)
	,(15,7,2)
	,(16,8,2)
	,(17,1,3)
	,(18,2,3)
	,(19,3,3)
	,(20,4,3)
	,(21,5,3)
	,(22,6,3)
	,(23,7,3)
	,(24,8,3)
	SET IDENTITY_INSERT dbo.SucursalFeriado OFF;
END