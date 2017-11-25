CREATE PROCEDURE [dbo].[UpdateLesson]
    @id INT,
    @name NVARCHAR(50) = NULL,
	@content NVARCHAR(MAX) = NULL
AS
BEGIN
	UPDATE Lesson SET Name = ISNULL(@name, Name), Content = ISNULL(@content, Content)
	WHERE id = @id
END