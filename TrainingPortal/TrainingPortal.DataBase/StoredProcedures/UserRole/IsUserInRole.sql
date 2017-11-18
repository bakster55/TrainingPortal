CREATE PROCEDURE [dbo].[IsUserInRole]
	@userId INT,
	@roleName NVARCHAR(50)
AS
	DECLARE @isInRole INT;
	SET @isInRole = 0;
	IF (EXISTS(SELECT * FROM UserRole WHERE UserId = @userId AND RoleId = (SELECT Id FROM Role WHERE Name = @roleName)))
	BEGIN
		SET @isInRole = 1;
	END;
RETURN @isInRole