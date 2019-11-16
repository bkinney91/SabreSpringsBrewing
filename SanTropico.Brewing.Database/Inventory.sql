CREATE TABLE [dbo].[Inventory]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Brand] nvarchar(255),
	[Description] nvarchar(max),
	[Type] nvarchar(255),
	[UnitOfMeasure] nvarchar(255),
	[PricePerUnitOfMeasure] decimal not null,
	[Quantity] decimal not null,
	[Notes] nvarchar(max),
	[Created] DateTime not null default GETDATE(),
	[CreatedBy] nvarchar(255)
)
