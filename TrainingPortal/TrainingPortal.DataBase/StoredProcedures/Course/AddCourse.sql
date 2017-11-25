CREATE PROCEDURE [dbo].[AddCourse]
	@name NVARCHAR(50),
	@description NVARCHAR(MAX),
	@categoryId INT
AS
	INSERT INTO [Course] VALUES(@name, @description, @categoryId)
RETURN 0
