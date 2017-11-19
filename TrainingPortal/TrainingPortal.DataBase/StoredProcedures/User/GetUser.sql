CREATE PROCEDURE [dbo].[GetUser]
	@email NVARCHAR(50) = NULL OUTPUT,
	@name NVARCHAR(50) = NULL OUTPUT,
	@passwordHash NVARCHAR(MAX) = NULL OUTPUT,
	@id int = NULL OUTPUT
AS
	SELECT @id = [User].Id, @email = [User].Email, @name = [User].Name, @passwordHash = [User].PasswordHash FROM [User]
	WHERE ((@email IS NULL) OR (Email = @email)) AND ((@name IS NULL) OR (Name = @name)) AND ((@id IS NULL) OR (Id = @id))
RETURN 0
