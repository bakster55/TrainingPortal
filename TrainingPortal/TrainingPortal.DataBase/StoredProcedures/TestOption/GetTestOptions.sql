CREATE PROCEDURE [dbo].[GetTestOptions]
	@testId int
AS
	SELECT * FROM TestOption WHERE TestId = @testId 
RETURN 0