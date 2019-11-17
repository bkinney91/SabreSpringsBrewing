CREATE TABLE [dbo].[BrewLogBillOfMaterials]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Batch] INT FOREIGN KEY REFERENCES Batches(Id) NOT NULL,
	[Inventory] INT FOREIGN KEY REFERENCES Inventory(Id) NOT NULL,
	[Quantity] decimal not null,
	[Created] DateTime not null DEFAULT GETDATE(),
	[CreatedBy] nvarchar(255) null
)
