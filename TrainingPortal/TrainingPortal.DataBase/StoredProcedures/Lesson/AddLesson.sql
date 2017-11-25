CREATE PROCEDURE [dbo].[AddLesson]
	@courseId INT,
	@name NVARCHAR(50),
	@content NVARCHAR(MAX)
AS
	INSERT INTO Lesson VALUES(@courseId, @name, @content)
RETURN 0
