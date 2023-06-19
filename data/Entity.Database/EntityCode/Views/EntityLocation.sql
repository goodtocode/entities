Create View [EntityCode].[EntityLocation]
As
Select	C.EntityLocationId As [Id],
		C.EntityLocationKey As [Key],
        C.EntityKey,
        C.LocationKey,
        L.LocationName,
        L.LocationDescription,
        IsNull(C.LocationTypeKey, '00000000-0000-0000-0000-000000000000') As [LocationTypeKey],
		C.CreatedDate,
		C.ModifiedDate
From	[Entity].[EntityLocation] C
    Join [Entity].[Location] L On C.LocationKey = L.LocationKey
Where   C.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'