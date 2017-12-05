CREATE PROCEDURE [dbo].[AddCertificate]
	@id UNIQUEIDENTIFIER,
	@userId INT,
	@result INT,
	@courseId INT
AS
	INSERT INTO [Certificate] VALUES(@id, @userId, @result, @courseId)
RETURN 0
