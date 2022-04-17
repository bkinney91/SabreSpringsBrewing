CREATE TABLE Beers (
	Id INTEGER PRIMARY KEY, 
    Name TEXT NULL, 
    Style TEXT NULL,
	SuggestedGlassType TEXT null,
	Logo TEXT NULL,
	Created DateTime default CURRENT_TIMESTAMP,
	CreatedBy TEXT null
)
