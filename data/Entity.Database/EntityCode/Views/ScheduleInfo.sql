Create VIEW [EntityCode].[ScheduleInfo]
AS 
	Select	S.ScheduleId As [Id], 
			S.ScheduleKey As [Key],
            S.ScheduleName As [Name],
            S.ScheduleDescription As [Description],
            S.RecordStateKey,
			S.CreatedDate, 
			S.ModifiedDate
	From	[Entity].[Schedule] S
    Where   S.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'