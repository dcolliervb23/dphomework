CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AddressLine1] NCHAR(10) NULL, 
    [AddressLine2] NCHAR(10) NULL, 
    [City] NCHAR(10) NULL, 
    [State] NCHAR(10) NULL, 
    [Zip] NCHAR(10) NULL, 
    [IndividualId] INT NULL, 
    CONSTRAINT [FK_Address_ToIndividual] FOREIGN KEY ([IndividualId]) REFERENCES [Individual]([Id])
)
