Create VIEW [EntityCode].[EventResource]
AS 
	Select	ESL.EventResourceId As [Id], 
			ESL.EventResourceKey As [Key],
			ESL.EventKey,
            E.EventName,
            E.EventDescription,
            E.EventCreatorKey,
            L.ResourceKey,
            L.ResourceName,
            L.ResourceDescription,
            IsNull(ESL.ResourceTypeKey, '00000000-0000-0000-0000-000000000000') As [ResourceTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[EventResource] ESL
        Join	[Entity].[Event] E On ESL.EventKey = E.EventKey
        Join	[Entity].[Resource] L On ESL.ResourceKey = L.ResourceKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'