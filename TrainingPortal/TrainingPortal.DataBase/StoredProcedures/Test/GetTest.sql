﻿CREATE PROCEDURE [dbo].[GetTest]
	@id INT
AS
	SELECT TOP 1 * FROM Test WHERE CourseId = @id
RETURN 0
