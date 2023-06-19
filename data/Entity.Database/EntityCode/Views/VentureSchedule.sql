Create VIEW [EntityCode].[VentureSchedule]
AS 
	Select	ESL.VentureScheduleId As [Id], 
			ESL.VentureScheduleKey As [Key],
			ESL.VentureKey,
            E.VentureName,
            E.VentureDescription,
            L.ScheduleKey,
            L.ScheduleName,
            L.ScheduleDescription,
            IsNull(ESL.ScheduleTypeKey, '00000000-0000-0000-0000-000000000000') As [ScheduleTypeKey],
			ESL.CreatedDate, 
			ESL.ModifiedDate
	From	[Entity].[VentureSchedule] ESL
        Join	[Entity].[Venture] E On ESL.VentureKey = E.VentureKey
        Join	[Entity].[Schedule] L On ESL.ScheduleKey = L.ScheduleKey
    Where   ESL.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'