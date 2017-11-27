CREATE PROCEDURE [dbo].[UpdateTest]
    @id INT,
	@question NVARCHAR(MAX) = NULL
AS
BEGIN
	UPDATE Test SET Question = ISNULL(@question, Question)
	WHERE id = @id
END