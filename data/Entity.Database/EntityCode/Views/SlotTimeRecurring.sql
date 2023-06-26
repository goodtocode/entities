Create VIEW [EntityCode].[SlotTimeRecurring]
AS 
	Select	ST.SlotTimeRecurringId As [Id], 
			ST.SlotTimeRecurringKey As [Key],
            S.SlotKey,
            S.SlotName,
            S.SlotDescription,
            TR.BeginDay,
            TR.EndDay,
            TR.BeginTime,
            TR.EndTime,
            TR.Interval,
            TR.TimeCycleKey,
            IsNull(ST.TimeTypeKey, '00000000-0000-0000-0000-000000000000') As [TimeTypeKey],
            IsNull(TT.TimeBehavior, 1) As [TimeBehavior],
            ST.RecordStateKey,
			ST.CreatedDate, 
			ST.ModifiedDate
	From	[Entity].[SlotTimeRecurring] ST    
        Join    [Entity].[Slot] S On ST.SlotKey = S.SlotKey
        Join	[Entity].[TimeRecurring] TR On ST.TimeRecurringKey = TR.TimeRecurringKey
        Left Join    [Entity].[TimeType] TT On ST.TimeTypeKey = TT.TimeTypeKey
    Where   ST.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'