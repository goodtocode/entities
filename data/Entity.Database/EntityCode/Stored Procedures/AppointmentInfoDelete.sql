Create Procedure [EntityCode].[AppointmentInfoDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(AppointmentId, -1) From [Entity].[Appointment] P Where [AppointmentKey] = @Key
            If (@Id <> -1)
			Begin
	            Update	[Entity].[Appointment]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	AppointmentId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End