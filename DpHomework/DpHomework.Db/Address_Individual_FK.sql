ALTER TABLE [dbo].[SomeTableOrView]
	ADD CONSTRAINT [Address_Individual_FK]
	FOREIGN KEY (SomeColumn)
	REFERENCES [SomeTable] (SomeColumn)
