Create VIEW [EntityCode].[SlotInfo]
AS 
	Select	S.SlotId As [Id], 
			S.SlotKey As [Key],
            S.SlotName As [Name],
            S.SlotDescription As [Description],
            S.RecordStateKey,
			S.CreatedDate, 
			S.ModifiedDate
	From	[Entity].[Slot] S
    Where   S.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'