CREATE PROCEDURE [dbo].[UpdateCourse]
    @id INT,
    @name NVARCHAR(50) = NULL,
    @description NVARCHAR(MAX) = NULL,
	@categoryId INT,
	@audienceId INT
AS
BEGIN
    UPDATE [Course] SET 
	AudienceId = @audienceId, 
	CategoryId = @categoryId, 
	Description = ISNULL(@description, Description), 
	Name = ISNULL(@name , Name)
	WHERE id = @id
END