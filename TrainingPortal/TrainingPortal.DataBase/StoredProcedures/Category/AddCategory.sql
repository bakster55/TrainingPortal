﻿CREATE PROCEDURE [dbo].[AddCategory]
	@name NVARCHAR(50)
AS
	INSERT INTO Category VALUES(@name)
RETURN 0
