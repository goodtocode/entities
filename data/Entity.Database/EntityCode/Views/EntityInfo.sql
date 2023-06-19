Create View [EntityCode].[EntityInfo]
As
Select	C.EntityId As [Id],
		C.EntityKey As [Key],
		C.CreatedDate, 
		C.ModifiedDate
From	[Entity].[Entity] C
