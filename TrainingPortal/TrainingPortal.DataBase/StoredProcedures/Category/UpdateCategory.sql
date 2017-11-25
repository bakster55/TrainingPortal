CREATE PROCEDURE [dbo].[UpdateCategory]
    @id INT,
    @name NVARCHAR(50) = NULL
AS
BEGIN
    UPDATE Category SET Name=ISNULL(@name,Name)
	WHERE id=@id
END