CREATE PROCEDURE [dbo].[UpdateTestOption]
    @id INT,
	@name NVARCHAR(50),
	@isChecked BIT
AS
BEGIN
	UPDATE TestOption SET Name = ISNULL(@name, Name), IsChecked = ISNULL(@isChecked, IsChecked)
	WHERE id = @id
END