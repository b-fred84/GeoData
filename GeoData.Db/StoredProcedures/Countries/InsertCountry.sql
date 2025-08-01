﻿CREATE PROCEDURE [dbo].[InsertCountry]

	@IsoCode2 CHAR(2),
	@Name NVARCHAR(50),
	@IsoCode3 CHAR(3),
	@Population INT = NULL,
	@PopulationYear INT = NULL,
	@Continent CHAR(13) = NULL,
	@Area INT = NULL
	
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM Countries WHERE IsoCode2 = @IsoCode2)
	BEGIN
		INSERT INTO Countries (IsoCode2, [Name], IsoCode3, [Population], PopulationYear, Area) 
		VALUES (@IsoCode2, @Name, @IsoCode3, @Population, @PopulationYear, @Area);
	END
END