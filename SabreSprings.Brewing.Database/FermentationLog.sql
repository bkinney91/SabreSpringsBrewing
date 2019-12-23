CREATE TABLE [dbo].[FermentationLog]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Batch] INTEGER NOT NULL,
	[Temperature] DECIMAL NOT NULL,
	[Gravity] DECIMAL NOT NULL,
	[Angle] DECIMAL NOT NULL,
	[DeviceNumber] INTEGER NOT NULL,
	[Created] DateTime default CURRENT_TIMESTAMP,
	FOREIGN KEY(Batch) REFERENCES Batches(Id),
)
