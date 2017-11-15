CREATE PROCEDURE [dbo].[AddUser]
	@name nvarchar(50),
	@email nvarchar(50),
	@passwordHash nvarchar(50),
	@token nvarchar(50)
AS
	INSERT INTO [User] VALUES(@name, @email, @passwordHash, @token)
RETURN 0
