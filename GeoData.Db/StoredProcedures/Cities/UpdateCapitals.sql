CREATE PROCEDURE [dbo].[UpdateCapitals]
	@CountryId CHAR(2),
	@Name NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Cities
	SET IsCapital = 1
	WHERE CountryId = @CountryId AND [Name] = @Name
END

