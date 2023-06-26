Create VIEW [EntityCode].[EntityTimeRecurring]
AS 
	Select	LTA.EntityTimeRecurringId As [Id], 
			LTA.EntityTimeRecurringKey As [Key],
            L.EntityKey,
            TA.BeginDay,
            TA.EndDay,
            TA.BeginTime,
            TA.EndTime,
            TA.Interval,
            IsNull(LTA.TimeTypeKey, '00000000-0000-0000-0000-000000000000') As [TimeTypeKey],
			LTA.CreatedDate, 
			LTA.ModifiedDate
	From	[Entity].[EntityTimeRecurring] LTA
        Join	[Entity].[Entity] L On LTA.EntityKey = L.EntityKey    
        Join	[Entity].[TimeRecurring] TA On LTA.TimeRecurringKey = TA.TimeRecurringKey
    Where   LTA.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'