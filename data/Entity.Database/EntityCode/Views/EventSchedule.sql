Create VIEW [EntityCode].[EventSchedule]
AS 
	Select	ESL.EventScheduleId As [Id], 
			ESL.EventScheduleKey As [Key],
			ESL.EventKey,
            E.EventName,
            E.EventDescription,
            E.EventCreatorKey,
            L.ScheduleKey,
            L.ScheduleName,
            L.ScheduleDescription,
            IsNull(ESL.ScheduleTypeKey, '00000000-0000-0000-0000-000000000000') As [ScheduleTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[EventSchedule] ESL
        Join	[Entity].[Event] E On ESL.EventKey = E.EventKey
        Join	[Entity].[Schedule] L On ESL.ScheduleKey = L.ScheduleKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'