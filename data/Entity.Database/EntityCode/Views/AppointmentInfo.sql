Create VIEW [EntityCode].[AppointmentInfo]
AS 
	Select	A.AppointmentId As [Id], 
			A.AppointmentKey As [Key],
            A.AppointmentName As [Name], 
			A.AppointmentDescription As [Description],
            IsNull(A.SlotLocationKey, '00000000-0000-0000-0000-000000000000') As [SlotLocationKey], 
            IsNull(A.SlotResourceKey, '00000000-0000-0000-0000-000000000000') As [SlotResourceKey], 
			A.CreatedDate, 
			A.ModifiedDate, 
			
			A.TimeRangeKey,
			TR.BeginDate,
			TR.EndDate
	From	[Entity].[Appointment] A
	    Join	[Entity].[TimeRange] TR On A.TimeRangeKey = TR.TimeRangeKey
    Where   A.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'