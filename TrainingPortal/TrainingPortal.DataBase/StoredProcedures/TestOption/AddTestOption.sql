CREATE PROCEDURE [dbo].[AddTestOption]
	@testId INT,
	@name NVARCHAR(50),
	@isChecked BIT
AS
	INSERT INTO TestOption VALUES(@testId, @name, @isChecked)
RETURN 0
