CREATE TABLE Reviews
(
	Id INTEGER PRIMARY KEY,
	Beer INTEGER NOT NULL,	
	Rating INTEGER not null,
	Notes TEXT null,
	CreatedBy TEXT null,
	Created DateTime NOT NULL default CURRENT_TIMESTAMP,
	FOREIGN KEY(Beer) REFERENCES Beers(Id)
)
