CREATE TABLE [dbo].[Individual]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NULL, 
    [Email] VARCHAR(250) NULL
)
