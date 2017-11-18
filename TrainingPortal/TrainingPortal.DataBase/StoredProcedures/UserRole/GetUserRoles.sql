CREATE PROCEDURE [dbo].[GetUserRoles]
	@userId INT
AS
	SELECT Name FROM Role WHERE Id IN (SELECT RoleId FROM UserRole WHERE UserId = @userId)
RETURN 0
