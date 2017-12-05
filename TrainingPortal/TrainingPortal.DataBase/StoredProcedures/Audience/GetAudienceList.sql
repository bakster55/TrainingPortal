CREATE PROCEDURE [dbo].[GetAudienceList]
	@id int = NULL,
	@name NVARCHAR(50) = NULL
AS
	SELECT * FROM Audience
RETURN 0