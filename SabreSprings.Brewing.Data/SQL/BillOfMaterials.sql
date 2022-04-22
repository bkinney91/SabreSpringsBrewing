CREATE TABLE [BillOfMaterials]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[Batch] INTEGER NOT NULL,
	[Inventory] INTEGER NOT NULL,
	[Quantity] decimal not null,
	[Created] DateTime not null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null,
	FOREIGN KEY(Batch) REFERENCES Batches(Id),
	FOREIGN KEY(Inventory) REFERENCES Inventory(Id)
)
