CREATE TABLE [Fermentabuoy]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[DeviceId] INTEGER NOT NULL,
	[Name] nvarchar(256),
	[Created] DateTime not null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null
)
