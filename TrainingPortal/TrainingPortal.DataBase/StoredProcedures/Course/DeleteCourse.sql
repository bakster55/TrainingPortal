CREATE PROCEDURE [dbo].[DeleteCourse]
	@id INT
AS
	DELETE FROM [Course] WHERE Id = @id
RETURN 0
