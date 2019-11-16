CREATE TABLE [dbo].[BrewLogBillOfMaterials]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Batch] INT FOREIGN KEY REFERENCES Batches(Id),
	[Inventory] INT FOREIGN KEY REFERENCES Inventory(Id),
	[Quantity] decimal not null,
	[Created] DateTime not null DEFAULT GETDATE(),
	[CreatedBy] nvarchar(255) null
)
