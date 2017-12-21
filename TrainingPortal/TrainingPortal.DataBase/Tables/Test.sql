﻿CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[CourseId] INT NOT NULL FOREIGN KEY REFERENCES Course (Id) ON DELETE CASCADE,
	[Question] NVARCHAR(MAX) NOT NULL,
)
