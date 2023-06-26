Create VIEW [EntityCode].[SlotTimeRange]
AS 
	Select	ST.SlotTimeRangeId As [Id], 
			ST.SlotTimeRangeKey As [Key],
            S.SlotKey,
            S.SlotName,
            S.SlotDescription,
            TR.BeginDate,
            TR.EndDate,
            IsNull(ST.TimeTypeKey, '00000000-0000-0000-0000-000000000000') As [TimeTypeKey],
            IsNull(TT.TimeBehavior, 1) As [TimeBehavior],
            ST.RecordStateKey,
			ST.CreatedDate, 
			ST.ModifiedDate
	From	[Entity].[SlotTimeRange] ST		
        Join    [Entity].[Slot] S On ST.SlotKey = S.SlotKey
        Join	[Entity].[TimeRange] TR On ST.TimeRangeKey = TR.TimeRangeKey
		Left Join    [Entity].[TimeType] TT On ST.TimeTypeKey = TT.TimeTypeKey
    Where   ST.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'