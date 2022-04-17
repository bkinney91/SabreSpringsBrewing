CREATE TABLE [FermentabuoyAssignment]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[Batch] INTEGER NOT NULL,
	[Fermentabuoy] INTEGER NOT NULL,
	[Created] DateTime not null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null,
	FOREIGN KEY(Batch) REFERENCES Batches(Id),
	FOREIGN KEY(Fermentabuoy) REFERENCES Fermentabuoy(Id)
)