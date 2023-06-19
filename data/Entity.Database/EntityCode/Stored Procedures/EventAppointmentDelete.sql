Create Procedure [EntityCode].[EventAppointmentDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([EventAppointmentKey], @Key) From [Entity].[EventAppointment] Where [EventAppointmentId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventAppointmentId], -1) From [Entity].[EventAppointment] Where [EventAppointmentKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[EventAppointment]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	EventAppointmentId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End