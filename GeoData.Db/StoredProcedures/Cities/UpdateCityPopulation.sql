CREATE PROCEDURE [dbo].[UpdateCityPopulation]
	@CountryId CHAR(2),
	@CityName NVARCHAR(50),
	@Population INT = NULL,
	@PopulationYear INT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Cities
	SET
		[Population] = CASE WHEN @Population IS NOT NULL THEN @Population ELSE [Population] END,
		PopulationYear = CASE WHEN @PopulationYear IS NOT NULL THEN @PopulationYear ELSE PopulationYear END
	WHERE CountryId = @CountryId AND [Name] = @CityName
END
