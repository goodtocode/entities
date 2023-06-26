Create VIEW [EntityCode].[ResourceInfo]
AS 
	Select	S.ResourceId As [Id], 
			S.ResourceKey As [Key],
            S.ResourceName As [Name],
            S.ResourceDescription As [Description],
            S.RecordStateKey,
			S.CreatedDate, 
			S.ModifiedDate
	From	[Entity].[Resource] S        
    Where   S.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'
