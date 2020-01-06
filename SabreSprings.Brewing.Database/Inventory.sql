CREATE TABLE [Inventory]
(
	[Id] INTEGER PRIMARY KEY NOT NULL,
	[Material] INT not null,
	[UnitOfMeasure] TEXT NOT NULL,
	[PricePerUnitOfMeasure] decimal not null,
	[Quantity] decimal not null,
	[Notes] TEXT,
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL,
	FOREIGN KEY(Material) REFERENCES Materials(Id)
)
