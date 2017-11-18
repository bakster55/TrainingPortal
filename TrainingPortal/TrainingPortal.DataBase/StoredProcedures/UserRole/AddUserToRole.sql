CREATE PROCEDURE [dbo].[AddUserToRole]
	@userId INT,
	@roleName NVARCHAR(50)
AS
	INSERT INTO [UserRole] VALUES(@userId, (SELECT Id FROM Role WHERE Name = @roleName))
RETURN 0