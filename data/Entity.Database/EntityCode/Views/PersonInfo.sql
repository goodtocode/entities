Create View [EntityCode].[PersonInfo]
As
Select	P.PersonId As [Id],
		P.PersonKey As [Key],
		P.FirstName, 
		P.MiddleName, 
		P.LastName,
		P.BirthDate,
		IsNull(G.GenderCode, '') As GenderCode,
		P.CreatedDate, 
		P.ModifiedDate
From	[Entity].[Person] P
Left Join [Entity].[Gender] G On P.GenderId = G.GenderId
Where   P.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'