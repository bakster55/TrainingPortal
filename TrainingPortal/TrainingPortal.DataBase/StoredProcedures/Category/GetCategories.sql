CREATE PROCEDURE [dbo].[GetCategories]
	@id int = NULL,
	@name NVARCHAR(50) = NULL
AS
	SELECT * FROM Category
RETURN 0