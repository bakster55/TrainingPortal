CREATE PROCEDURE [dbo].[DeleteCategory]
	@id INT
AS
	DELETE FROM Category WHERE Id = @id
RETURN 0
