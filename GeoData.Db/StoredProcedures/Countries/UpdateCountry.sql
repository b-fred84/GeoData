CREATE PROCEDURE [dbo].[UpdateCountry]
	@IsoCode3 CHAR(3),
	@Population INT = NULL,
	@PopulationYear INT = NULL,
	@Continent CHAR(13) = NULL,
	@Language NVARCHAR(50) = NULL,
	@Area INT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Countries
	SET
		[Population] = CASE WHEN @Population IS NOT NULL THEN @Population ELSE [Population] END,
		PopulationYear = CASE WHEN @PopulationYear IS NOT NULL THEN @PopulationYear ELSE PopulationYear END,
		Continent = CASE WHEN @Continent IS NOT NULL THEN @Continent ELSE Continent END,
		[Language] = CASE WHEN @Language IS NOT NULL THEN @Language ELSE [Language] END,
		Area = CASE WHEN @Area IS NOT NULL THEN @Area ELSE Area END
	WHERE 
		IsoCode3 = @IsoCode3;

END