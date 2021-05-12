CREATE TABLE TerrainDetails (
	TerrainID varchar(20) not null primary key,
	TerrainDescription varchar(8000),
	TerrainTravelSpeed int not null
)

CREATE TABLE RandomEncounters (
	RandEncounterTableId varchar(50) primary key not null,
	RandEncounter varchar(8000)
)

CREATE TABLE Provinces (
	Coordinates int not null primary key,
	ProvinceName varchar(100),
	TerrainID varchar(20) not null foreign key references TerrainDetails,
	ObviousFeature varchar(8000),
	HiddenFeature varchar(8000),
	RandEncounterTableId varchar(50) foreign key references RandomEncounters
)

CREATE TABLE Characters (
	CharacterID int primary key not null,
	CharacterName varchar(30),
	IsPlayerCharacter bit,
	CharacterDescription varchar(8000),
	Coordinates int not null foreign key references Provinces,
)

SELECT * FROM TerrainDetails
SELECT * FROM RandomEncounters
SELECT * FROM Provinces
SELECT * FROM Characters