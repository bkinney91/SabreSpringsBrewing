﻿CREATE TABLE [dbo].[Reviews]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Beer] INT FOREIGN KEY REFERENCES Beers(Id) NOT NULL,
	[Rating] int not null,
	[Notes] nvarchar(max) null,
	[CreatedBy] nvarchar(255) null,
	[Created] DateTime NOT NULL default GETDATE()
)