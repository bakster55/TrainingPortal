CREATE PROCEDURE [dbo].[IsUserInRole]
	@userId INT,
	@roleName NVARCHAR(50)
AS
	SELECT * FROM UserRole WHERE UserId = @userId AND RoleId = (SELECT Id FROM Role WHERE Name = @roleName)
RETURN 0