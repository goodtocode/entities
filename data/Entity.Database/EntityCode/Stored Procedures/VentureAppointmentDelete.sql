Create Procedure [EntityCode].[VentureAppointmentDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([VentureAppointmentKey], @Key) From [Entity].[VentureAppointment] Where [VentureAppointmentId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureAppointmentId], -1) From [Entity].[VentureAppointment] Where [VentureAppointmentKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[VentureAppointment]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	VentureAppointmentId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End