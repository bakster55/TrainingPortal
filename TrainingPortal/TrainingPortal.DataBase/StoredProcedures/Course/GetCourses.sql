CREATE PROCEDURE [dbo].[GetCourses]
	@id int = NULL,
	@name NVARCHAR(50) = NULL,
	@description NVARCHAR(MAX) = NULL
AS
	SELECT * FROM [Course] 
		LEFT JOIN Category ON Course.CategoryId = Category.Id 
		LEFT JOIN Audience ON Course.AudienceId = Audience.Id
RETURN 0