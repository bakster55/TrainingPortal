CREATE PROCEDURE [dbo].[UpdateRole]
    @id int,
    @name nvarchar(50) = NULL
AS
BEGIN
    UPDATE [Role] SET Name=ISNULL(@name, Name) WHERE id=@id
END