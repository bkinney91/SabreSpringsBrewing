CREATE TABLE [Tasks]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[Batch] INTEGER NOT NULL,
	[Description] TEXT null,
	[ProjectedCompletion] DateTime not null,
	[ActualCompletion] DateTime null,
	[CompletedBy] TEXT null,
	[Created] DateTime not null default CURRENT_TIMESTAMP
)
