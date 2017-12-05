CREATE PROCEDURE [dbo].[DeleteAudience]
	@id INT
AS
	DELETE FROM Audience WHERE Id = @id
RETURN 0
