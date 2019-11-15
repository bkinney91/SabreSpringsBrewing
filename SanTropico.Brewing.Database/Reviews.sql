CREATE TABLE [dbo].[Reviews]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Rating] int not null,
	[Notes] nvarchar(max) null,
	[CreatedBy] nvarchar(255) null,
	[Created] DateTime default GETDATE()
)
