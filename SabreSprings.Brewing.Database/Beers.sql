CREATE TABLE Beers (
	Id INTEGER PRIMARY KEY, 
    Name TEXT NULL, 
    Style TEXT NULL,
	SuggestedGlassType TEXT null,
	Created DateTime default CURRENT_TIMESTAMP,
	CreatedBy TEXT null
)
