Create Procedure [EntityCode].[EventLocationDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([EventLocationKey], @Key) From [Entity].[EventLocation] Where [EventLocationId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([EventLocationId], -1) From [Entity].[EventLocation] Where [EventLocationKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[EventLocation]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	EventLocationId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End