CREATE PROCEDURE [dbo].[GetTests]
	@courseId int
AS
	SELECT * FROM Test WHERE CourseId = @courseId
RETURN 0