CREATE PROCEDURE [dbo].[AddCertificate]
	@id UNIQUEIDENTIFIER,
	@userId INT,
	@result INT,
	@courseId INT,
	@date DATE
AS
	INSERT INTO [Certificate] VALUES(@id, @userId, @result, @courseId, @date)
RETURN 0
