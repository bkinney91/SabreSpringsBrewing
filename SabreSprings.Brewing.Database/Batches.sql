CREATE TABLE [dbo].[Batches]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Beer] INT FOREIGN KEY REFERENCES Beers(Id) NOT NULL,
	[BatchNumber] INT not null,
	[BatchName] nvarchar(255) null,
	[Status] nvarchar(255),
	[SubStatus]nvarchar(255),
	[Brewers] Nvarchar(max), 
	[Recipe] Nvarchar(max),
	[Yeast] Nvarchar(max),
	[PreBoilGravity] decimal(4,3) null,
	[OriginalGravity] decimal(4,3) null,
	[FinalGravity] decimal(4,3) null,
	[ABV] decimal(2,1) null,
	[PintsRemaining]  decimal(5,2) null,
	[DateBrewed] DateTime null,
	[DatePackaged] DateTime null,
	[DateTapped] DateTime null,
	[BrewingNotes] nvarchar(max) null,
	[TastingNotes] nvarchar(max) null,
	[Created] nvarchar(max) NOT null DEFAULT GETDATE(),
	[CreatedBy] nvarchar(255) null
)
