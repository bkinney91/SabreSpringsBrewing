CREATE TABLE [dbo].[Inventory]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Brand] nvarchar(255) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[Type] nvarchar(255) NOT NULL,
	[UnitOfMeasure] nvarchar(255) NOT NULL,
	[PricePerUnitOfMeasure] decimal not null,
	[Quantity] decimal not null,
	[Notes] nvarchar(max),
	[Created] DateTime not null default GETDATE(),
	[CreatedBy] nvarchar(255)
)
