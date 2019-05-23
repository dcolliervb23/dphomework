CREATE PROCEDURE [dbo].[InsertIndividual]
	@firstName varchar(100),
	@lastName varchar(100),
	@middleName varchar(100),
	@email varchar(250)
AS
	INSERT INTO [dbo].[Individual] 
		([FirstName],
		[MiddleName],
		[LastName],
		[Email])
	VALUES
		(@firstName,
		@middleName,
		@lastName,
		@email)
select scope_identity() as Id
GO

