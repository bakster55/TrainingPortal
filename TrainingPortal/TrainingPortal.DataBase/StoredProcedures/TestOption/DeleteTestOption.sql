CREATE PROCEDURE [dbo].[DeleteTestOption]
	@id INT
AS
	DELETE FROM TestOption WHERE Id = @id
RETURN 0
