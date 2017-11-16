CREATE PROCEDURE [dbo].[AddUser]
	@id INT OUTPUT,
	@name NVARCHAR(50),
	@email NVARCHAR(50),
	@passwordHash NVARCHAR(MAX)
AS
	INSERT INTO [User] VALUES(@name, @email, @passwordHash)
	SELECT @id = SCOPE_IDENTITY()
RETURN 0
