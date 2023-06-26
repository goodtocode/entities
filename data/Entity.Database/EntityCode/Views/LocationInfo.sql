Create VIEW [EntityCode].[LocationInfo]
AS 
	Select	L.LocationId As [Id], 
			L.LocationKey As [Key],
            L.LocationName As [Name],
            L.LocationDescription As [Description],
			L.CreatedDate, 
			L.ModifiedDate
	From	[Entity].[Location] L 
    Where   L.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'