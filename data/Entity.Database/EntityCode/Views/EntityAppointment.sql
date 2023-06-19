Create VIEW [EntityCode].[EntityAppointment]
AS 
	Select	EA.EntityAppointmentId As [Id], 
			EA.EntityAppointmentKey As [Key],
			EA.EntityKey,
            A.AppointmentKey,
            A.AppointmentName,
            A.AppointmentDescription,
            A.TimeRangeKey,
            TR.BeginDate,
			TR.EndDate,
            IsNull(A.SlotLocationKey, '00000000-0000-0000-0000-000000000000') As [SlotLocationKey], 
            IsNull(A.SlotResourceKey, '00000000-0000-0000-0000-000000000000') As [SlotResourceKey], 
			EA.CreatedDate, 
			EA.ModifiedDate
	From	[Entity].[EntityAppointment] EA
        Join	[Entity].[Entity] E On EA.EntityKey = E.EntityKey
        Join	[Entity].[Appointment] A On EA.AppointmentKey = A.AppointmentKey
        Join	[Entity].[TimeRange] TR On A.TimeRangeKey = TR.TimeRangeKey
    Where   EA.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'