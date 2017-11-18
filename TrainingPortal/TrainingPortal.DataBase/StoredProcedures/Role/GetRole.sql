CREATE PROCEDURE [dbo].[GetRole]
	@name NVARCHAR(50) = NULL OUTPUT,
	@id int = NULL OUTPUT
AS
	SELECT @id = [Role].Id, @name = [Role].Name FROM [Role]
	WHERE ((@name IS NULL) OR (Name = @name)) AND ((@id IS NULL) OR (Id = @id))
RETURN 0
