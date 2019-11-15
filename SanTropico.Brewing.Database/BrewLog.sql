CREATE TABLE [dbo].[BrewLog]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Beer] INT FOREIGN KEY REFERENCES Beers(Id),
	[Batch] INT not null,
	[Brewers] Nvarchar(max), 
	[Recipe] Nvarchar(max),
	[Yeast] Nvarchar(max),
	[PreBoilGravity] decimal(4,3) null,
	[OriginalGravity] decimal(4,3) null,
	[FinalGravity] decimal(4,3) null,
	[ABV] decimal(2,1) null,
	[DateBrewed] DateTime null,
	[DatePackaged] DateTime null,
	[DateTapped] DateTime null,
	[BrewingNotes] nvarchar(max) null,
	[TastingNotes] nvarchar(max) null,
	[Created] nvarchar(max) null,
	[CreatedBy] nvarchar(255) null
)
