Create View [EntityCode].[ResourceItem]
As
Select	RP.ResourceItemId As [Id],
		RP.ResourceItemKey As [Key],
		R.ResourceKey,
        R.ResourceName, 
		R.ResourceDescription, 
		P.ItemKey,
        P.ItemName, 
		P.ItemDescription, 
		P.ItemTypeKey,
		RP.CreatedDate, 
		RP.ModifiedDate
From	[Entity].[ResourceItem] RP
    Join [Entity].[Resource] R On RP.ResourceKey = R.ResourceKey
    Join [Entity].[Item] P On RP.ItemKey = P.ItemKey
Where   RP.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'