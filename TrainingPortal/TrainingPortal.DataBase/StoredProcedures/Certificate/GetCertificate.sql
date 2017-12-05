CREATE PROCEDURE [dbo].[GetCertificate]
	@userId INT,
	@courseId INT
AS
	SELECT TOP 1 * FROM [Certificate] WHERE UserId = @userId AND CourseId = @courseId
RETURN 0
