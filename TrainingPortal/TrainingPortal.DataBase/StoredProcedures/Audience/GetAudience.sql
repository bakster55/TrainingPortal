CREATE PROCEDURE [dbo].[GetAudience]
	@id INT
AS
	SELECT TOP 1 * FROM Audience WHERE Id = @id
RETURN 0
