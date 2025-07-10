CREATE TABLE [dbo].[Countries]
(
    [IsoCode2] CHAR(2) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL, 
    [IsoCode3] CHAR(3) NOT NULL, 
    [Population] INT NULL, 
    [PopulationYear] INT NULL,
    [Continent] CHAR(13) NULL, 
    [Language] NVARCHAR(50) NULL, 
    [Area] INT NULL,
)
