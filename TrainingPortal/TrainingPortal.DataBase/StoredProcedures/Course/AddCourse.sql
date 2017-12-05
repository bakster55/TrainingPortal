CREATE PROCEDURE [dbo].[AddCourse]
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@categoryId INT,
	@audienceId INT
AS
	INSERT INTO [Course] VALUES(@name, @description, @categoryId, @audienceId)
RETURN 0
