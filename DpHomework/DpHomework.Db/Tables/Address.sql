CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AddressLine1] VARCHAR(100) NULL, 
    [AddressLine2] VARCHAR(100) NULL, 
    [City] VARCHAR(100) NULL, 
    [State] VARCHAR(35) NULL, 
    [Zip] VARCHAR(10) NULL, 
    [IndividualId] INT NULL, 
    CONSTRAINT [FK_Address_ToIndividual] FOREIGN KEY ([IndividualId]) REFERENCES [Individual]([Id])
)
