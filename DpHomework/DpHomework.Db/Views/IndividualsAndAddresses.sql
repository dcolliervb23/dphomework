CREATE VIEW [dbo].[IndividualsAndAddresses]
	AS SELECT ind.*, ad.id as AddressId, ad.AddressLine1, ad.AddressLine2, ad.City, ad.State, ad.Zip
	FROM [Individual] ind
	LEFT JOIN [Address] ad on ad.IndividualId = ind.Id
