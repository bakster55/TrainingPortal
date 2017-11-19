CREATE PROCEDURE [dbo].[GetCourse]
	@id INT
AS
	SELECT TOP 1 * FROM [Course] WHERE Id = @id
RETURN 0
