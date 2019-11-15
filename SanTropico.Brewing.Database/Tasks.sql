CREATE TABLE [dbo].[Tasks]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[BrewLog] INT FOREIGN KEY REFERENCES BrewLog(Id),
	[Description] nvarchar(max) null,
	[ProjectedCompletion] DateTime not null,
	[ActualCompletion] DateTime null,
	[CompletedBy] nvarchar(255) null,
	[Created] DateTime not null default GETDATE(),
	[CreatedBy] nvarchar(255)
)
