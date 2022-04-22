CREATE TABLE [Fermentabuoy]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[DeviceId] INTEGER NOT NULL,
	[DeviceNumber] INTEGER NOT NULL,
	[MacAddress] nvarchar(256),
	[Created] DateTime not null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null
)
