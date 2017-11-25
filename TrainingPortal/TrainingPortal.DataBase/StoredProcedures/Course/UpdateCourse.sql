CREATE PROCEDURE [dbo].[UpdateCourse]
    @id INT,
    @name NVARCHAR(50) = NULL,
    @description NVARCHAR(MAX) = NULL,
	@categoryId INT
AS
BEGIN
    UPDATE [Course] SET CategoryId = @categoryId, Description=ISNULL(@description,Description), Name=ISNULL(@name,Name)
	WHERE id=@id
END