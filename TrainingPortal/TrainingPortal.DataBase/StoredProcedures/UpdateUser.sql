CREATE PROCEDURE [dbo].[UpdateUser]
    @id int,
    @email nvarchar(50) = NULL,
    @name nvarchar(50) = NULL,
    @passwordHash nvarchar(MAX) = NULL
AS
BEGIN
    UPDATE [User]
    SET Email=ISNULL(@email,Email), 
        Name=ISNULL(@name,Name), 
        PasswordHash=ISNULL(@passwordHash, PasswordHash)
    WHERE id=@id
END