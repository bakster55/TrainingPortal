CREATE PROCEDURE [dbo].[GetCourses]
	@id int = NULL,
	@name NVARCHAR(50) = NULL,
	@description NVARCHAR(MAX) = NULL
AS
	SELECT * FROM [Course]
RETURN 0