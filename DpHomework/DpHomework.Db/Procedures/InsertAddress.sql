CREATE PROCEDURE [dbo].[InsertAddress]
	@addressLine1 varchar(100),
	@addressLine2 varchar(100),
	@city varchar(100),
	@state varchar(35),
	@zip varchar(10),
	@individualId int
AS
	INSERT INTO [dbo].[Address]
		(AddressLine1,
		AddressLine2,
		City,
		[State],
		[Zip],
		[IndividualId])
	VALUES
		(@addressLine1,
		@addressLine2,
		@city,
		@state,
		@zip,
		@individualId)
select scope_identity() as Id
GO

