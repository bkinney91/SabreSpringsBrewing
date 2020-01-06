CREATE TABLE [dbo].[Materials]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Type] TEXT not null,
	[Description] TEXT not null,
	[Attribute] TEXT not null,
	[Created] DateTime not null default CURRENT_TIMESTAMP,
	[CreatedBy] TEXT NOT NULL

)