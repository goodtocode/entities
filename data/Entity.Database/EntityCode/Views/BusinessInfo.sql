Create View [EntityCode].[BusinessInfo]
As
Select	B.BusinessId As [Id],
		B.BusinessKey As [Key],
		B.BusinessName As Name,
		B.TaxNumber, 		
		B.CreatedDate, 
		B.ModifiedDate
From	[Entity].[Business] B
Where   B.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'
