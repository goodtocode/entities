Create Procedure [EntityCode].[LocationTimeRecurringDelete]
	@Id	                INT,
    @Key				uniqueidentifier
AS
    Begin
    	
		Begin Try			
			-- Id and Key are both valid. Sync now.
		    If (@Id <> -1) Select Top 1 @Key = IsNull([LocationTimeRecurringKey], @Key) From [Entity].[LocationTimeRecurring] Where [LocationTimeRecurringId] = @Id
		    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([LocationTimeRecurringId], -1) From [Entity].[LocationTimeRecurring] Where [LocationTimeRecurringKey] = @Key
            -- Validate
            If (@Id <> -1)
			Begin
	            Update	[Entity].[LocationTimeRecurring]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	LocationTimeRecurringId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByException];
			
		End Catch
    End