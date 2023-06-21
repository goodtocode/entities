--
--
--
Use EntityData
Go
Select Top 10 *
From	EntityData.Entity.ResourceItem
Order By ResourceItemId Desc


-- View
Select	RP.ResourceItemId As [Id],
		RP.ResourceItemKey As [Key],
		R.ResourceKey,
        R.ResourceName, 
		R.ResourceDescription, 
		P.ItemKey,
        P.ItemName, 
		P.ItemDescription, 
		P.ItemGroupKey, 
		P.ItemTypeKey,
		RP.CreatedActivityKey As ActivityContextKey,
		RP.CreatedDate, 
		RP.ModifiedDate
From	[Entity].[ResourceItem] RP
    Join [Entity].[Resource] R On RP.ResourceKey = R.ResourceKey
    Join [Entity].[Item] P On RP.ItemKey = P.ItemKey