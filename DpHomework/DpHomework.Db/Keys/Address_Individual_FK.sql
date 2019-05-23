ALTER TABLE [dbo].[Address]
	ADD CONSTRAINT [Address_Individual_FK]
	FOREIGN KEY (IndividualId)
	REFERENCES [Individual] (Id)
