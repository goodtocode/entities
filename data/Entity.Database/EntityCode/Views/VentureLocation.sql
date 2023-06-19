Create VIEW [EntityCode].[VentureLocation]
AS 
	Select	ESL.VentureLocationId As [Id], 
			ESL.VentureLocationKey As [Key],
			ESL.VentureKey,
            E.VentureName,
            E.VentureDescription,
            L.LocationKey,
            L.LocationName,
            L.LocationDescription,
            IsNull(ESL.LocationTypeKey, '00000000-0000-0000-0000-000000000000') As [LocationTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[VentureLocation] ESL
        Join	[Entity].[Venture] E On ESL.VentureKey = E.VentureKey
        Join	[Entity].[Location] L On ESL.LocationKey = L.LocationKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'