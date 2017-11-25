﻿CREATE TABLE [dbo].[Lesson]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[CourseId] INT NOT NULL FOREIGN KEY REFERENCES Course (Id),
	[Name] NVARCHAR(50) NOT NULL,
	[Content] NVARCHAR(MAX) NULL
)
