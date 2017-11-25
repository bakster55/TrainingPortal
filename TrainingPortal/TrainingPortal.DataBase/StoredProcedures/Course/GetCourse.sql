CREATE PROCEDURE [dbo].[GetCourse]
	@id INT
AS
	SELECT TOP 1 * FROM [Course] INNER JOIN Category ON Course.CategoryId = Category.Id WHERE Course.Id = @id
RETURN 0
