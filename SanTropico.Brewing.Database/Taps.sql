CREATE TABLE [dbo].[Taps]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[TapNumber] INT not null,
	[BrewLog] INT FOREIGN KEY REFERENCES BrewLog(Id),
	[PintsRemaining] decimal (5,3) null,
	[Status] nvarchar(255) Default 'On Deck',
	[Created] DateTime not null default GETDATE(),
	[CreatedBy] nvarchar(255) not null
)
