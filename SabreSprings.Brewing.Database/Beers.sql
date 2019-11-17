﻿CREATE TABLE [dbo].[Beers]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(55) NULL, 
    [Style] NVARCHAR(255) NULL,
	[SuggestedGlassType] nvarchar(255) null,
	[Created] DateTime default GETDATE(),
	[CreatedBy] Nvarchar(255) null
)