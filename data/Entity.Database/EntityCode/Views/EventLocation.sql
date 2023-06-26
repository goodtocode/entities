Create VIEW [EntityCode].[EventLocation]
AS 
	Select	ESL.EventLocationId As [Id], 
			ESL.EventLocationKey As [Key],
			ESL.EventKey,
            E.EventName,
            E.EventDescription,
            E.EventCreatorKey,
            L.LocationKey,
            L.LocationName,
            L.LocationDescription,
            IsNull(ESL.LocationTypeKey, '00000000-0000-0000-0000-000000000000') As [LocationTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[EventLocation] ESL
        Join	[Entity].[Event] E On ESL.EventKey = E.EventKey
        Join	[Entity].[Location] L On ESL.LocationKey = L.LocationKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'