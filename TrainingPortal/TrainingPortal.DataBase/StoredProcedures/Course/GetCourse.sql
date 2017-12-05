CREATE PROCEDURE [dbo].[GetCourse]
	@id INT
AS
	SELECT TOP 1 * FROM [Course] 
		LEFT JOIN Category ON Course.CategoryId = Category.Id
		LEFT JOIN Audience ON Course.AudienceId = Audience.Id WHERE Course.Id = @id
RETURN 0
