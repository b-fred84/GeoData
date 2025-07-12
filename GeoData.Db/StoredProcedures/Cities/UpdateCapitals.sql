CREATE PROCEDURE [dbo].[UpdateCapitals]
	@CountryId CHAR(2),
	@Name NVARCHAR(50)
AS
BEGIN
	UPDATE Cities
	SET IsCapital = 1
	WHERE CountryId = @CountryId AND [Name] = @Name
END

