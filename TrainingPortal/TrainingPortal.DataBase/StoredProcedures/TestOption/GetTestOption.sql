CREATE PROCEDURE [dbo].[GetTestOption]
	@id INT
AS
	SELECT TOP 1 * FROM TestOption WHERE Id = @id
RETURN 0
