﻿CREATE PROCEDURE [dbo].[AddAudience]
	@name NVARCHAR(50)
AS
	INSERT INTO Audience VALUES(@name)
RETURN 0
