Create View [EntityCode].[GovernmentInfo]
As
Select	G.GovernmentId As [Id],
		G.GovernmentKey As [Key],
		G.GovernmentName As Name,
		G.CreatedDate, 
		G.ModifiedDate
From	[Entity].[Government] G
Where   G.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'
