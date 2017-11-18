CREATE PROCEDURE [dbo].[DeleteUserFromRole]
	@userId INT,
	@roleName NVARCHAR(50)
AS
	DELETE FROM [UserRole] WHERE UserId = @userId AND RoleId = (SELECT Id FROM Role WHERE Name = @roleName);
RETURN 0
