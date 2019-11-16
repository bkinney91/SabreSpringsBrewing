CREATE TABLE [dbo].[Tasks]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Batch] INT FOREIGN KEY REFERENCES Batches(Id),
	[Description] nvarchar(max) null,
	[ProjectedCompletion] DateTime not null,
	[ActualCompletion] DateTime null,
	[CompletedBy] nvarchar(255) null,
	[Created] DateTime not null default GETDATE(),
	[CreatedBy] nvarchar(255)
)
