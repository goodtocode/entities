Create VIEW [EntityCode].[VentureInfo]
AS 
	Select	E.VentureId As [Id], 
			E.VentureKey As [Key],
			E.VentureGroupKey,
			E.VentureTypeKey,
			E.VentureName As Name, 
			E.VentureDescription As [Description], 
			E.VentureSlogan As Slogan, 
			E.CreatedDate, 
			E.ModifiedDate
	From	[Entity].[Venture] E
    Where   E.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'

