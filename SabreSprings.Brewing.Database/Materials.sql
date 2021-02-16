CREATE TABLE [Materials]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[Type] INTEGER not null,
	[Description] TEXT not null,
	[UnitOfMeasure] TEXT null,
	[Created] DateTime not null default CURRENT_TIMESTAMP
)