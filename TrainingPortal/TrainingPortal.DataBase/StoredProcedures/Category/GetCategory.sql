CREATE PROCEDURE [dbo].[GetCategory]
	@id INT
AS
	SELECT TOP 1 * FROM Category WHERE Id = @id
RETURN 0
