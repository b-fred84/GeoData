CREATE PROCEDURE [dbo].[InsertCity]
	@Name NVARCHAR(50),
	@CountryId CHAR(2),
	@Population INT = NULL,
	@PopulationYear INT = NULL,
	@IsCapital BIT = 0

AS
BEGIN
	IF NOT EXISTS ( SELECT 1 FROM Cities WHERE [Name] = @Name AND CountryId = @CountryId )
	BEGIN
		INSERT INTO Cities ([Name], CountryId, [Population], PopulationYear, IsCapital)
		VALUES (@Name, @CountryId, @Population, @PopulationYear, @IsCapital)
	END
END