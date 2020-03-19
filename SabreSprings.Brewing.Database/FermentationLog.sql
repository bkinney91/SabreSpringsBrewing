CREATE TABLE [dbo].[FermentationLog]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] TEXT NOT NULL,
	[Temperature] DECIMAL NOT NULL,
	[Gravity] DECIMAL NOT NULL,
	[Angle] DECIMAL NOT NULL,
	[DeviceNumber] INTEGER NOT NULL,
	[Battery] DECIMAL NOT NULL,
	[RSSI] INTEGER NOT NULL,
	[Created] DateTime default CURRENT_TIMESTAMP,	
)
