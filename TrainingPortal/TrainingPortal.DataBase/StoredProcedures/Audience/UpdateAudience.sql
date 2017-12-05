CREATE PROCEDURE [dbo].[UpdateAudience]
    @id INT,
    @name NVARCHAR(50) = NULL
AS
BEGIN
    UPDATE Audience SET Name = ISNULL(@name, Name)
	WHERE id = @id
END