Create VIEW [EntityCode].[SlotLocation]
AS 
	Select  SL.SlotLocationId As [Id], 
			SL.SlotLocationKey As [Key],
            S.SlotKey,
            S.SlotName,
            S.SlotDescription,
            L.LocationKey,
            L.LocationName,
            L.LocationDescription,
            IsNull(SL.LocationTypeKey, '00000000-0000-0000-0000-000000000000') As [LocationTypeKey],
            SL.RecordStateKey,
			SL.CreatedDate, 
			SL.ModifiedDate
	From	[Entity].[SlotLocation] SL
        Join	[Entity].[Slot] S On SL.SlotKey = S.SlotKey
        Join	[Entity].[Location] L On SL.LocationKey = L.LocationKey
    Where   SL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'