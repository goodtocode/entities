Create VIEW [EntityCode].[ItemInfo]
AS 
	Select	L.ItemId As [Id], 
			L.ItemKey As [Key],
            L.ItemName As [Name],
            L.ItemDescription As [Description],
            L.ItemTypeKey,
			L.CreatedDate, 
			L.ModifiedDate
	From	[Entity].[Item] L 
    Where   L.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'