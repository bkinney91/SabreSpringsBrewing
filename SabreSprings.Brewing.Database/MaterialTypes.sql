CREATE TABLE [MaterialTypes]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Type] TEXT NOT NULL,
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL
)