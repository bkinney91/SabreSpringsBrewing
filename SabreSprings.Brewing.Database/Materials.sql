CREATE TABLE [Materials]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[PointOfUse] TEXT not null,
	[Type] TEXT not null,
	[Description] TEXT not null,
	[Attributes] TEXT null,
	[Notes] TEXT null,
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL
)