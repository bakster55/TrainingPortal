﻿CREATE PROCEDURE [dbo].[GetLesson]
	@id INT
AS
	SELECT TOP 1 * FROM Lesson WHERE Id = @id
RETURN 0
