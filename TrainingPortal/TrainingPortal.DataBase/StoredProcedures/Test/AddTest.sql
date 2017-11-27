CREATE PROCEDURE [dbo].[AddTest]
	@courseId INT,
	@question NVARCHAR(MAX)
AS
	INSERT INTO Test VALUES(@courseId, @question)
RETURN 0
