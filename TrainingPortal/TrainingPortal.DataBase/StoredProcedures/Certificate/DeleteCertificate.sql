CREATE PROCEDURE [dbo].[DeleteCertificate]
	@id UNIQUEIDENTIFIER
AS
	DELETE FROM [Certificate] WHERE Id = @id
RETURN 0
