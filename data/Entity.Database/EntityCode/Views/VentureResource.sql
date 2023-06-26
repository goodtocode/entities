Create VIEW [EntityCode].[VentureResource]
AS 
	Select	ESL.VentureResourceId As [Id], 
			ESL.VentureResourceKey As [Key],
			ESL.VentureKey,
            E.VentureName,
            E.VentureDescription,
            L.ResourceKey,
            L.ResourceName,
            L.ResourceDescription,
            IsNull(ESL.ResourceTypeKey, '00000000-0000-0000-0000-000000000000') As [ResourceTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[VentureResource] ESL
        Join	[Entity].[Venture] E On ESL.VentureKey = E.VentureKey
        Join	[Entity].[Resource] L On ESL.ResourceKey = L.ResourceKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'