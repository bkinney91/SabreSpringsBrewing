CREATE TABLE [RecipeMaterials]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Recipe] INT Not null,
	[Material] TEXT not null,	
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL,
	FOREIGN KEY(Recipe) REFERENCES Recipes(Id),
	FOREIGN KEY(Material) REFERENCES Materials(Id)
)