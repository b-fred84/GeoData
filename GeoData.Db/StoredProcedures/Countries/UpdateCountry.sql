CREATE PROCEDURE [dbo].[UpdateCountry]
    @Iso2 CHAR(2) = NULL,
	@Iso3 CHAR(3) = NULL,
	@Population INT = NULL,
	@PopulationYear INT = NULL,
	@Continent CHAR(13) = NULL,
	@Area INT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Countries
	SET
		[Population] = CASE WHEN @Population IS NOT NULL THEN @Population ELSE [Population] END,
		PopulationYear = CASE WHEN @PopulationYear IS NOT NULL THEN @PopulationYear ELSE PopulationYear END,
		Continent = CASE WHEN @Continent IS NOT NULL THEN @Continent ELSE Continent END,
		Area = CASE WHEN @Area IS NOT NULL THEN @Area ELSE Area END
	WHERE 
		(
			(@Iso2 IS NOT NULL AND IsoCode2 = @Iso2)
			OR
			(@Iso2 IS NULL AND @Iso3 IS NOT NULL AND IsoCode3 = @Iso3)

		
		)

END