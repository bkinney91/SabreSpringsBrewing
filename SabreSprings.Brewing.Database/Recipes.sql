﻿CREATE TABLE [Recipes]
(
	[Id] INTEGER NOT NULL PRIMARY KEY,
	[BoilTime] INTEGER NOT NULL,
	[Beer] integer not null,
	[Yeast] TEXT not null,
	[PitchTemperature] int not null,
	[FermentationTemperatureLow] int null,
	[FermentationTemperatureHigh] int null,
	[StrikeWaterVolume] decimal(2,2) null,
	[StrikeWaterTemperature] int null,
	[SpargeWaterTemperature] int null,
	[SpargeWaterVolume] decimal(4,3) null,
	[PreBoilVolume] decimal(4,3) null,
	[MashTemperature] int not null,
	[MashInstructions] TEXT not null,
	[DaysInPrimaryFermentation] int not null,
	[DaysInSecondaryFermentation] int not null,
	[SecondaryFermentationRequired] bit not null,
	[PreBoilGravity] decimal(4,3) null,
	[OriginalGravity] decimal(4,3) null,
	[FinalGravity] decimal(4,3) null,
	[ABV] decimal(2,2) null,
	[IBU] decimal(2,2) null,
	[SRM] decimal (3,2) null,
	[MashPh] decimal(2,2) null,
	[BrewingNotes] TEXT null,
	[FermentationNotes] TEXT null,
	[Created] TEXT NOT null DEFAULT CURRENT_TIMESTAMP,
	[CreatedBy] TEXT null
)
