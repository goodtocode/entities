Create VIEW [EntityCode].[ResourceTimeRecurring]
AS 
	Select	RTA.ResourceTimeRecurringId As [Id], 
			RTA.ResourceTimeRecurringKey As [Key],
            L.ResourceKey,
            L.ResourceName,
            L.ResourceDescription,
            TA.BeginDay,
            TA.EndDay,
            TA.BeginTime,
            TA.EndTime,
            TA.Interval,
            IsNull(RTA.TimeTypeKey, '00000000-0000-0000-0000-000000000000') As [TimeTypeKey],
			RTA.CreatedDate, 
			RTA.ModifiedDate
	From	[Entity].[ResourceTimeRecurring] RTA
        Join	[Entity].[Resource] L On RTA.ResourceKey = L.ResourceKey    
        Join	[Entity].[TimeRecurring] TA On RTA.TimeRecurringKey = TA.TimeRecurringKey
    Where   RTA.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'