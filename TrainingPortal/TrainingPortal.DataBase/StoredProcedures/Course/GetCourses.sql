CREATE PROCEDURE [dbo].[GetCourses]
	@id int = NULL,
	@name NVARCHAR(50) = NULL,
	@description NVARCHAR(MAX) = NULL
AS
	SELECT * FROM [Course] INNER JOIN Category ON Course.CategoryId = Category.Id
RETURN 0