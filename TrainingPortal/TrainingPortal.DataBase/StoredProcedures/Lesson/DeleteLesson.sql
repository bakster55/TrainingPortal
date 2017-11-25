CREATE PROCEDURE [dbo].[DeleteLesson]
	@id INT
AS
	DELETE FROM Lesson WHERE Id = @id
RETURN 0
