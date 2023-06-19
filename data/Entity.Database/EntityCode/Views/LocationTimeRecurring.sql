Create VIEW [EntityCode].[LocationTimeRecurring]
AS 
	Select	LTA.LocationTimeRecurringId As [Id], 
			LTA.LocationTimeRecurringKey As [Key],
            L.LocationKey,
            L.LocationName,
            L.LocationDescription,
            TA.BeginDay,
            TA.EndDay,
            TA.BeginTime,
            TA.EndTime,
            TA.Interval,
            IsNull(LTA.TimeTypeKey, '00000000-0000-0000-0000-000000000000') As [TimeTypeKey],
			LTA.CreatedDate, 
			LTA.ModifiedDate
	From	[Entity].[LocationTimeRecurring] LTA
        Join	[Entity].[Location] L On LTA.LocationKey = L.LocationKey    
        Join	[Entity].[TimeRecurring] TA On LTA.TimeRecurringKey = TA.TimeRecurringKey
    Where   LTA.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'