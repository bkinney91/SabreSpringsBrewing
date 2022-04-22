CREATE TABLE [Inventory]
(
	[Id] INTEGER PRIMARY KEY NOT NULL,
	[Brand] TEXT NOT NULL,
	[Description] TEXT NOT NULL,
	[Type] TEXT NOT NULL,
	[UnitOfMeasure] TEXT NOT NULL,
	[PricePerUnitOfMeasure] decimal not null,
	[Quantity] decimal not null,
	[Notes] TEXT,
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL
)
