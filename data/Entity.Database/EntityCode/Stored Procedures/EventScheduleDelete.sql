Create Procedure [EntityCode].[EventScheduleDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([EventScheduleKey], @Key) From [Entity].[EventSchedule] Where [EventScheduleId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventScheduleId], -1) From [Entity].[EventSchedule] Where [EventScheduleKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[EventSchedule]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	EventScheduleId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End