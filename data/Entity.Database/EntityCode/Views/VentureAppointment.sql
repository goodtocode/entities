Create VIEW [EntityCode].[VentureAppointment]
AS 
	Select	EA.VentureAppointmentId As [Id], 
			EA.VentureAppointmentKey As [Key],
			EA.VentureKey,
            E.VentureName,
            E.VentureDescription,
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
	From	[Entity].[VentureAppointment] EA
        Join	[Entity].[Venture] E On EA.VentureKey = E.VentureKey
        Join	[Entity].[Appointment] A On EA.AppointmentKey = A.AppointmentKey
        Join	[Entity].[TimeRange] TR On A.TimeRangeKey = TR.TimeRangeKey
    Where   EA.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'