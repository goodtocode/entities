Create VIEW [EntityCode].[SlotResource]
AS 
	Select  SL.SlotResourceId As [Id], 
			SL.SlotResourceKey As [Key],
            S.SlotKey,
            S.SlotName,
            S.SlotDescription,
            L.ResourceKey,
            L.ResourceName,
            L.ResourceDescription,
            IsNull(SL.ResourceTypeKey, '00000000-0000-0000-0000-000000000000') As [ResourceTypeKey],
            SL.RecordStateKey,
			SL.CreatedDate, 
			SL.ModifiedDate
	From	[Entity].[SlotResource] SL
        Join	[Entity].[Slot] S On SL.SlotKey = S.SlotKey
        Join	[Entity].[Resource] L On SL.ResourceKey = L.ResourceKey
    Where   SL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'