CREATE TABLE [dbo].[Cities]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CountryId] CHAR(2) NOT NULL, 
    [Population] INT NULL, 
    [PopulationYear] INT NULL, 
    [IsCapital] BIT NOT NULL, 
    CONSTRAINT [FK_Cities_Countries] FOREIGN KEY ([CountryId]) REFERENCES [Countries]([IsoCode2])
)
