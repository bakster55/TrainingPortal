CREATE PROCEDURE [dbo].[AddCourse]
	@name NVARCHAR(50),
	@description NVARCHAR(MAX)
AS
	INSERT INTO [Course] VALUES(@name, @description)
RETURN 0
