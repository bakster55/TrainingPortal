CREATE PROCEDURE [dbo].[GetLessons]
	@courseId int
AS
	SELECT * FROM Lesson WHERE CourseId = @courseId 
RETURN 0