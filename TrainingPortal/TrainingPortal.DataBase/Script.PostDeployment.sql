/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [Role] Values ('admin'), ('editor')
INSERT INTO [Role] Values('editor')

INSERT INTO [User] Values('admin', 'a@a.com', 'ANJgDYTRGFvkAA9GKeD7VyKrZBDqEANVOpGslwfSLC48Rg/MiWOFlJ2hk5lKzKKywQ==')
INSERT INTO [User] Values('editor', 'e@e.com', 'ANJgDYTRGFvkAA9GKeD7VyKrZBDqEANVOpGslwfSLC48Rg/MiWOFlJ2hk5lKzKKywQ==')

INSERT INTO [UserRole] Values 
	(
		(SELECT TOP 1 Id FROM [User] WHERE [Name] = 'admin'), 
		(SELECT TOP 1 Id FROM [Role] WHERE [Name] = 'admin')
	),
	(
		(SELECT TOP 1 Id FROM [User] WHERE [Name] = 'editor'), 
		(SELECT TOP 1 Id FROM [Role] WHERE [Name] = 'editor')
	)

INSERT INTO [Category] Values('Java'), ('C#'), ('JavaScript'), ('Html')

INSERT INTO [Audience] Values('Novice'), ('Advanced'), ('Professional')

INSERT INTO [Course] Values
	(
		'Object Oriented Programming in C#',
		'Want to learn a different programming language? C# is a great place to start.',
		(SELECT TOP 1 Id FROM [Category] WHERE [Name] = 'C#'), 
		(SELECT TOP 1 Id FROM [Audience] WHERE [Name] = 'Novice')
	), 
	(
		'Introduction To JavaScript',
		'JavaScript is a widely used web-based programming language that powers the dynamic behavior on most websites, including this one.',
		(SELECT TOP 1 Id FROM [Category] WHERE [Name] = 'JavaScript'), 
		(SELECT TOP 1 Id FROM [Audience] WHERE [Name] = 'Professional')
	), 
	(
		'HTML Fundamentals',
		'Spoiler alert: every web page on the Internet is secretly written in HyperText Markup Language, otherwise known as "HTML." So why dont you see code and markup everywhere? Well, your browser reads HTML for you and just shows you the pretty version. It is sheltering you!',
		(SELECT TOP 1 Id FROM [Category] WHERE [Name] = 'Html'), 
		(SELECT TOP 1 Id FROM [Audience] WHERE [Name] = 'Advanced')
	)