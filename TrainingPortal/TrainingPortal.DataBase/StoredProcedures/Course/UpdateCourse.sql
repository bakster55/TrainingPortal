CREATE PROCEDURE [dbo].[UpdateCourse]
    @id INT,
    @name NVARCHAR(50) = NULL,
    @description NVARCHAR(MAX) = NULL
AS
BEGIN
    UPDATE [Course] SET Description=ISNULL(@description,Description), Name=ISNULL(@name,Name)
	WHERE id=@id
END