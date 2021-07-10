CREATE TABLE [Stages]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Name] TEXT NOT NULL,
	[Created] DateTime not null default CURRENT_TIMESTAMP
)